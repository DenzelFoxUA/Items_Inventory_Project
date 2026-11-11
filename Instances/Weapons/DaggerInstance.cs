
using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{
    public class DaggerInstance
        : WeaponInstance<IAffectImmediately<IAffectableCharacter>, 
            IAffectableCharacter>
    {
        private DaggerDefinition Dagger => (DaggerDefinition)Definition;

        private Action<IOwnedEquipable>? _useFunction = null;
        private Func<string, IOwnedEquipable?>? _unequipFunction = null;

        public DaggerInstance(DaggerDefinition daggerItem, 
            params IAffectImmediately<IAffectableCharacter>[]? effects) : base(daggerItem, effects)
        {

        }

        public override void Use()
        {
            SetTargetFunction();

            if (!IsEquipped)
                _useFunction.Invoke(this);
            else
                _unequipFunction.Invoke(this.GetEquipSlotCategory());
        }

        public override void Equip()
        {
            if (IsEquipped)
                return;

            IsEquipped = true;

        }

        public override void Unequip()
        {
            if (!IsEquipped)
                return;

            IsEquipped = false;

            CancelMyTarget();
        }

        public override void SetTargetFunction()
        {
            if (MyOwner is not null)
            {
                _useFunction = MyOwner.Equip;
                _unequipFunction = MyOwner.Unequip;
            }
        }

        public override AttackComplex<IAffectImmediately<IAffectableCharacter>, IAffectableCharacter> 
            PrimaryAttack(IAffectable? target)
        {
            if (Dagger.PrimaryAttack == null)
                throw new ArgumentNullException("ERR::Primary attack not set!");

            var dmg = Dagger.PrimaryAttack.MaxDamage;
            var dist = Dagger.PrimaryAttack.AttackRange;

            return new AttackComplex<IAffectImmediately<IAffectableCharacter>,
                IAffectableCharacter>(dmg, dist, Effects.ToList());
        }

        public override AttackComplex<IAffectImmediately<IAffectableCharacter>, IAffectableCharacter>? 
            SecondaryAttack(IAffectable? target)
        {
            if (Dagger.SecondaryAttack is null)
                return null;

            return null;
        }
    }
}
