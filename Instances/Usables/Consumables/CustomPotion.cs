
using CharacterMainLib;
using System;
using System.Linq;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class CustomPotion : UsableItemInstance<IAffectImmediately<IAffectableActor>>
    {

        public CustomPotion(PotionDefinition potion, uint stackCount, 
            params IAffectImmediately<IAffectableActor>[] effects) 
            : base(potion, stackCount, effects)
        {
            
        }

        public override object? Use()
        {
            if (CurrentStackCount > 0)
            {
                if(_target is IAffectableCharacter character)
                {
                    return Effects.ToList<IAffectImmediately<IAffectableCharacter>>();
                }

                return Effects.ToList<IAffectImmediately<IAffectableActor>>();

            }

            return null;
        }

        //public override void SetItemTarget(IAffectableActor? target)
        //{
        //    Target = target as IAffectableCharacter;

        //    if (Effects.Count != 0)
        //    {
        //        foreach (var eff in Effects)
        //            eff.SetTarget(Target);
        //    }

        //}
    }
}
