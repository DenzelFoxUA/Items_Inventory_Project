
using CharacterMainLib;
using System;
using System.Linq;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class CustomPotionInstnce : UsableItemInstance
    {

        public CustomPotionInstnce(PotionDefinition potion, params IAffect<IAffectableActor>[] effects) 
            : base(potion,effects)
        {
            
        }

        public override List<IAffect<IAffectableActor>>? Use()
        {
            if (CurrentStackCount > 0)
            {
                return Effects.ToList();
            }

            return null;
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
    }
}
