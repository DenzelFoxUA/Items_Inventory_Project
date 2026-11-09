

using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public class LeatherArmor : ArmorInstance<IAffectConditionally<IAffectableCharacter>>
    {
        private Action<IOwnedEquipable>? _useFunction = null;
        private Func<string, IOwnedEquipable?>? _unequipFunction = null;

        public LeatherArmor(in BodyArmor armor, 
            params IAffectConditionally<IAffectableCharacter>[] effects) 
            : base(armor, effects)
        {
           
        }

        public override void SetTargetFunction()
        {
            if(MyOwner is not null)
            {
                _useFunction = MyOwner.Equip;
                _unequipFunction = MyOwner.Unequip;
            }
           
        }

        public override void Use()
        {
            SetTargetFunction();

            _useFunction.Invoke(this);

        }

        public override void Equip()
        {
            if (IsEquipped)
                return;

            IsEquipped = true;

            foreach (var effect in Effects)
            {
                effect.SetTarget(MyOwner);
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
                effect.SetTarget(MyOwner);
                effect.Remove();
            }
        }
    }
}
