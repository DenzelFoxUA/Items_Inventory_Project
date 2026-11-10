using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{
    public class Amulet : 
        JewelryInstance<IAffectConditionally<IAffectableCharacter>, IAffectableCharacter>
    {

        private Action<IOwnedEquipable>? _useFunction = null;
        private Func<string, IOwnedEquipable?>? _unequipFunction = null;

        public Amulet(EquipableItem definition, 
            params IAffectConditionally<IAffectableCharacter>[] effects) 
            : base(definition, effects)
        {

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

        public override void SetTargetFunction()
        {
            if (MyOwner is not null)
            {
                _useFunction = MyOwner.Equip;
                _unequipFunction = MyOwner.Unequip;
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

            CancelMyTarget();
            
        }

        public override void Use()
        {
            SetTargetFunction();

            if (!IsEquipped)
                _useFunction.Invoke(this);
            else
                _unequipFunction.Invoke(this.GetEquipSlotCategory());
        }
    }
}
