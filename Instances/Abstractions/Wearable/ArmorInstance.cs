
using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public abstract class ArmorInstance<Effect, Target>: 
        DurableInstance<Effect,Target>, 
        IReducePhysicalDamage
        where Effect : class, IAffectConditionally<Target>
        where Target : class, IAffectableCharacter
    {

        private BaseArmor Armor
        {
            get
            {
                if (Definition is null)
                    throw new ObjectNotInitializedException(nameof(Definition));
                else
                    return (BaseArmor)Definition;
            }
        }

        private Action<IOwnedEquipable>? _useFunction = null;
        private Func<string, IOwnedEquipable?>? _unequipFunction = null;

        public uint CurrentDefence { get; protected set; }

        public ArmorInstance(in BaseArmor armor, 
            params Effect[] effects) : base(armor,effects)
        {
        }

        public override void Use()
        {
            SetTargetFunction();

            if (_useFunction is null || _unequipFunction is null)
                throw new NullReferenceException("Equip/Unequip funcs are not set");

            if (!IsEquipped)
                _useFunction.Invoke(this);
            else
                _unequipFunction.Invoke(this.GetEquipSlotCategory());

        }

        public override void SetTargetFunction()
        {
            if (MyOwner is not null)
            {
                _useFunction = MyOwner.Equip;
                _unequipFunction = MyOwner.Unequip;
            }

        }

        public override void Equip()
        {
            if (IsEquipped)
                return;

            IsEquipped = true;

            foreach (var effect in Effects)
            {
                effect.SetTarget(MyOwner as Target);
                effect.Apply();
            }

        }

        public override void Unequip()
        {
            if (!IsEquipped)
                return;

            IsEquipped = false;

            foreach (var effect in Effects)
            {
                effect.Remove();
            }

            CancelMyTarget();
        }

        public void ReduceDamage(ref uint damageIncome)
        {
            var durabilityCoef = GetDurabilityCoefficient();

            var reducePrcentage = (double)durabilityCoef >= 0.9 ? 0.9 : durabilityCoef;

            var result = damageIncome - damageIncome * reducePrcentage;

            damageIncome = (uint)Math.Round(result);
        }

        public override void Update()
        {
            var durabilityCoef = GetDurabilityCoefficient();

            CurrentDefence = (uint)Math.Round(Armor.MaxDefence * durabilityCoef);
        }

        public uint GetDefencePoints() => CurrentDefence;
    }
}
