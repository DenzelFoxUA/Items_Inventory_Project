
namespace InventoryCoreLib
{
    public class AttributeStat : CharacterStat
    {
        public uint CurrentValue { get; protected set; }

        public AttributeStat(uint minValue, uint maxValue) : base(minValue, maxValue)
        {
            CurrentValue = minValue;
        }

        public override void Increase(uint value)
        {
            if (CurrentValue >= MaxValue || value >= MaxValue - CurrentValue)
            {
                CurrentValue = MaxValue;
            }
            else
            {
                CurrentValue += value;
            }
        }

        public override void Decrease(uint value)
        {
            if (CurrentValue <= MinValue || value >= CurrentValue - MinValue)
            {
                CurrentValue = MinValue;
            }
            else
            {
                CurrentValue -= value;
            }
        }

        public override string ToString()
        {
            return $"{CurrentValue}";
        }
    }
}
