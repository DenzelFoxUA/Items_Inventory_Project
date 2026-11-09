using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{
    public class Amulet : JewelryInstance<IAffectConditionally<IAffectableCharacter>>
    {
        public Amulet(EquipableItem definition, 
            params IAffectConditionally<IAffectableCharacter>[] effects) 
            : base(definition, effects)
        {

        }

        public override void Equip()
        {
            if (IsEquipped)
                return;
            else
            {
                IsEquipped = true;
                SetItemTarget(MyOwner);
            }
        }

        public override void SetTargetFunction()
        {
            throw new NotImplementedException();
        }


        //public override void SetItemTarget(IAffectableActor? target)
        //{
        //    Owner = target as IAffectableCharacter;

        //    if (Effects.Count != 0)
        //    {
        //        foreach (var eff in Effects)
        //            eff.SetTarget(Owner);
        //    }
        //}

        public override void Unequip()
        {
            if (!IsEquipped)
                return;
            else
                IsEquipped = false;
        }

        public override void Use()
        {
            
        }
    }
}
