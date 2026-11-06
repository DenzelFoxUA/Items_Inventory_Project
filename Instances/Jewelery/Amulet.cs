using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;


namespace InventoryCoreLib
{
    public class Amulet : EquipableInstance
    {
        public Amulet(BaseItem definition, 
            params IAffect<IAffectableCharacter>[]? effects) : base(definition, effects)
        {

        }

        public override void Equip()
        {
            if (IsEquipped)
                return;
            else
            {
                IsEquipped = true;
                SetItemTarget(Target);
            }
                
            
        }

        public override void SetItemTarget<T>(T? target) where T : default
        {
            Target = target;

            if (Effects.Count != 0)
            {
                foreach (var eff in Effects)
                    eff.SetTarget(Target);
            }

        }

        public override void Unequip()
        {
            if (!IsEquipped)
                return;
            else
                IsEquipped = false;
        }

        public override List<IAffect<IAffectableCharacter>>? Use()
        {
            var res = Effects.ToList();
            return res;
        }
    }
}
