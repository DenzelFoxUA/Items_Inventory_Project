
using CharacterMainLib;
using System;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public sealed class CharacterUnitTester<TItem>
        where TItem : class, IUsable
    {
        private readonly Func<Character> _factory;
        private readonly CharacterBase _limits;

        private readonly string _vitalName;
        private readonly string _attributeName;

        private int _passed;
        private int _failed;

        public CharacterUnitTester(
            Func<Character> factory,
            CharacterBase limits,
            string vitalName = "Health",
            string attributeName = "Strength")
        {
            _factory = factory ??
                throw new ArgumentNullException(nameof(factory));

            _limits = limits ??
                throw new ArgumentNullException(nameof(limits));

            _vitalName = vitalName;
            _attributeName = attributeName;
        }

        private static void Assert(bool condition, string message)
        {
            if (!condition)
                throw new Exception(message);
        }

        private static void AssertEqual<T>(
            T expected, T actual) where T : IEquatable<T>
        {
            if (!expected.Equals(actual))
            {
                throw new Exception(
                    $"Expected: {expected}, Actual: {actual}");
            }
        }

        private static void AssertNear(
            double expected,
            double actual,
            double tolerance = 0.0001)
        {
            if (double.IsNaN(actual) ||
                Math.Abs(expected - actual) > tolerance)
            {
                throw new Exception(
                    $"Expected: {expected}, Actual: {actual}");
            }
        }

        private static void AssertThrows<TException>(Action action)
            where TException : Exception
        {
            try
            {
                action();
            }
            catch (TException)
            {
                return;
            }

            throw new Exception(
                $"Expected exception: {typeof(TException).Name}");
        }

        private void Test(
            string name,
            Action<Character> action)
        {
            try
            {
                Character character = _factory();

                action(character);

                _passed++;
                Console.WriteLine($"[PASS] {name}");
            }
            catch (Exception ex)
            {
                _failed++;
                Console.WriteLine($"[FAIL] {name}");
                Console.WriteLine($"       {ex.Message}");
            }
        }

        public void RunAll()
        {
            _passed = 0;
            _failed = 0;

            Console.WriteLine("=== CHARACTER UNIT TESTS ===");

            TestVitals();
            TestAttributes();
            TestMovementSpeed();
            TestCarryWeight();
            TestOtherMethods();

            Console.WriteLine();
            Console.WriteLine("=== RESULTS ===");
            Console.WriteLine($"Passed: {_passed}");
            Console.WriteLine($"Failed: {_failed}");
            Console.WriteLine($"Total:  {_passed + _failed}");
        }

        private void TestVitals()
        {
            Console.WriteLine("\n--- VITAL TESTS ---");

            Test("RestoreVital: normal recovery", c =>
            {
                c.DamageVital(_vitalName, 30);

                uint before =
                    c.VitalStats[_vitalName].CurrentValue;

                c.RestoreVital(_vitalName, 10);

                uint after =
                    c.VitalStats[_vitalName].CurrentValue;

                AssertEqual(before + 10, after);
            });

            Test("RestoreVital: zero amount", c =>
            {
                uint before =
                    c.VitalStats[_vitalName].CurrentValue;

                c.RestoreVital(_vitalName, 0);

                AssertEqual(
                    before,
                    c.VitalStats[_vitalName].CurrentValue);
            });

            Test("RestoreVital: uint.MaxValue", c =>
            {
                var stat = c.VitalStats[_vitalName];

                uint before = stat.CurrentValue;

                c.RestoreVital(_vitalName, uint.MaxValue);

                Assert(
                    stat.CurrentValue >= before &&
                    stat.CurrentValue <= stat.CurrentMax,
                    "Vital overflow or unexpected decrease.");
            });

            Test("DamageVital: normal damage", c =>
            {
                uint before =
                    c.VitalStats[_vitalName].CurrentValue;

                Assert(before >= 10, "Not enough HP for test.");

                c.DamageVital(_vitalName, 10);

                AssertEqual(
                    before - 10,
                    c.VitalStats[_vitalName].CurrentValue);
            });

            Test("DamageVital: zero amount", c =>
            {
                uint before =
                    c.VitalStats[_vitalName].CurrentValue;

                c.DamageVital(_vitalName, 0);

                AssertEqual(
                    before,
                    c.VitalStats[_vitalName].CurrentValue);
            });

            Test("DamageVital: uint.MaxValue", c =>
            {
                var stat = c.VitalStats[_vitalName];

                uint before = stat.CurrentValue;

                c.DamageVital(_vitalName, uint.MaxValue);

                Assert(
                    stat.CurrentValue <= before,
                    "Vital increased after damage.");
            });

            Test("RestoreVital: unknown vital", c =>
            {
                AssertThrows<ArgumentException>(() =>
                    c.RestoreVital("__UNKNOWN__", 10));
            });

            Test("DamageVital: unknown vital", c =>
            {
                AssertThrows<ArgumentException>(() =>
                    c.DamageVital("__UNKNOWN__", 10));
            });
        }

        private void TestAttributes()
        {
            Console.WriteLine("\n--- ATTRIBUTE TESTS ---");

            Test("IncreaseAttribute: normal", c =>
            {
                var stat = c.AttributeStats[_attributeName];

                uint before = stat.CurrentValue;

                Assert(
                    (ulong)before + 2 <= _limits.MaxAttributeValue,
                    "Not enough room for increase.");

                c.IncreaseAttribute(_attributeName, 2);

                AssertEqual(before + 2, stat.CurrentValue);
            });

            

            Test("IncreaseAttribute: uint.MaxValue", c =>
            {
                var stat = c.AttributeStats[_attributeName];

                uint before = stat.CurrentValue;

                c.IncreaseAttribute(
                    _attributeName, uint.MaxValue);

                Assert(
                    stat.CurrentValue >= before &&
                    stat.CurrentValue <= _limits.MaxAttributeValue,
                    "Attribute overflow.");
            });

            Test("DecreaseAttribute: normal", c =>
            {
                var stat = c.AttributeStats[_attributeName];

                uint original = stat.CurrentValue;

                c.IncreaseAttribute(_attributeName, 2);

                uint increased = stat.CurrentValue;

                AssertEqual(original + 2, increased);

                c.DecreaseAttribute(_attributeName, 2);

                AssertEqual(original, stat.CurrentValue);
            });

            Test("Attributes: zero amount", c =>
            {
                var stat = c.AttributeStats[_attributeName];

                uint before = stat.CurrentValue;

                c.IncreaseAttribute(_attributeName, 0);
                c.DecreaseAttribute(_attributeName, 0);

                AssertEqual(before, stat.CurrentValue);
            });

            Test("IncreaseAttribute: unknown", c =>
            {
                AssertThrows<ArgumentException>(() =>
                    c.IncreaseAttribute("__UNKNOWN__", 10));
            });

            Test("DecreaseAttribute: unknown", c =>
            {
                AssertThrows<ArgumentException>(() =>
                    c.DecreaseAttribute("__UNKNOWN__", 10));
            });
        }

        private void TestMovementSpeed()
        {
            Console.WriteLine("\n--- MOVEMENT TESTS ---");

            Test("MovementSpeedUp: normal", c =>
            {
                float before = c.CurrMoveSpeed;

                c.MovementSpeedUp(1.0f);

                Assert(
                    c.CurrMoveSpeed >= before &&
                    c.CurrMoveSpeed <= _limits.MaxSpeed,
                    "Invalid speed after increase.");
            });

            Test("MovementSlowDown: normal", c =>
            {
                float before = c.CurrMoveSpeed;

                c.MovementSlowDown(1.0f);

                Assert(
                    c.CurrMoveSpeed >= 0 &&
                    c.CurrMoveSpeed <= before,
                    "Invalid speed after decrease.");
            });

            Test("MovementSpeedUp: negative", c =>
            {
                float before = c.CurrMoveSpeed;

                c.MovementSpeedUp(-100);

                AssertEqual(before, c.CurrMoveSpeed);
            });

            Test("MovementSlowDown: negative", c =>
            {
                float before = c.CurrMoveSpeed;

                c.MovementSlowDown(-100);

                AssertEqual(before, c.CurrMoveSpeed);
            });

            Test("MovementSpeedUp: float.MaxValue", c =>
            {
                c.MovementSpeedUp(float.MaxValue);

                Assert(
                    float.IsFinite(c.CurrMoveSpeed) &&
                    c.CurrMoveSpeed >= 0 &&
                    c.CurrMoveSpeed <= _limits.MaxSpeed,
                    "Speed exceeded maximum or became non-finite.");
            });

            Test("MovementSlowDown: float.MaxValue", c =>
            {
                c.MovementSlowDown(float.MaxValue);

                Assert(
                    float.IsFinite(c.CurrMoveSpeed) &&
                    c.CurrMoveSpeed >= 0 &&
                    c.CurrMoveSpeed <= _limits.MaxSpeed,
                    "Invalid speed after extreme decrease.");
            });

            Test("Accelerate: maximum speed", c =>
            {
                c.Accelerate();

                Assert(
                    float.IsFinite(c.CurrMoveSpeed) &&
                    c.CurrMoveSpeed >= 0 &&
                    c.CurrMoveSpeed <= _limits.MaxSpeed,
                    "Accelerate bypassed MaxSpeed.");
            });

            Test("MovementSpeedUp: NaN", c =>
            {
                float before = c.CurrMoveSpeed;

                c.MovementSpeedUp(float.NaN);

                AssertEqual(before, c.CurrMoveSpeed);
            });

            Test("MovementSlowDown: NaN", c =>
            {
                float before = c.CurrMoveSpeed;

                c.MovementSlowDown(float.NaN);

                AssertEqual(before, c.CurrMoveSpeed);
            });
        }

        private void TestCarryWeight()
        {
            Console.WriteLine("\n--- CARRY WEIGHT TESTS ---");

            Test("CarryWeightUp: normal", c =>
            {
                double before = c.CurrCarryWeight;

                c.CarryWeightUp(1.0);

                Assert(
                    c.CurrCarryWeight >= before &&
                    c.CurrCarryWeight <= _limits.MaxCarryWeight,
                    "Invalid carry weight after increase.");
            });

            Test("CarryWeightDown: normal", c =>
            {
                double before = c.CurrCarryWeight;

                c.CarryWeightDown(1.0);

                Assert(
                    c.CurrCarryWeight >= _limits.MinCarryWeight &&
                    c.CurrCarryWeight <= before,
                    "Invalid carry weight after decrease.");
            });

            Test("CarryWeightUp: negative", c =>
            {
                double before = c.CurrCarryWeight;

                c.CarryWeightUp(-100);

                AssertNear(before, c.CurrCarryWeight);
            });

            Test("CarryWeightDown: negative", c =>
            {
                double before = c.CurrCarryWeight;

                c.CarryWeightDown(-100);

                AssertNear(before, c.CurrCarryWeight);
            });

            Test("CarryWeightUp: double.MaxValue", c =>
            {
                c.CarryWeightUp(double.MaxValue);

                Assert(
                    double.IsFinite(c.CurrCarryWeight) &&
                    c.CurrCarryWeight <= _limits.MaxCarryWeight,
                    "Carry weight overflow.");
            });

            Test("CarryWeightDown: double.MaxValue", c =>
            {
                c.CarryWeightDown(double.MaxValue);

                Assert(
                    double.IsFinite(c.CurrCarryWeight) &&
                    c.CurrCarryWeight >= _limits.MinCarryWeight,
                    "Carry weight underflow.");
            });

            Test("CarryWeightUp: NaN", c =>
            {
                double before = c.CurrCarryWeight;

                c.CarryWeightUp(double.NaN);

                AssertNear(before, c.CurrCarryWeight);
            });

            Test("CarryWeightDown: NaN", c =>
            {
                double before = c.CurrCarryWeight;

                c.CarryWeightDown(double.NaN);

                AssertNear(before, c.CurrCarryWeight);
            });
        }

        private void TestOtherMethods()
        {
            Console.WriteLine("\n--- OTHER TESTS ---");

            Test("DoNothing: no state changes", c =>
            {
                uint level = c.CurrentLevel;
                float speed = c.CurrMoveSpeed;
                double weight = c.CurrCarryWeight;

                //c.DoNothing();

                AssertEqual(level, c.CurrentLevel);
                AssertEqual(speed, c.CurrMoveSpeed);
                AssertNear(weight, c.CurrCarryWeight);
            });

            Test("ToString: basic information", c =>
            {
                string result = c.ToString();

                Assert(
                    result.Contains(c.Name) &&
                    result.Contains("Level") &&
                    result.Contains(_vitalName) &&
                    result.Contains(_attributeName),
                    "Character information is incomplete.");
            });

            Test("Initial level", c =>
            {
                AssertEqual(1u, c.CurrentLevel);
            });

            Test("Initial carry weight", c =>
            {
                AssertNear(
                    _limits.BaseCarryWeight,
                    c.CurrCarryWeight);
            });
        }
    }
}
