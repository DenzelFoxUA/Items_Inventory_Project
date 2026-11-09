
using CharacterMainLib;
using System;
using System.Linq;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class CustomPotion : UsableItemInstance<IAffectImmediately<IAffectableActor>>
    {

        private Action<IOwnedUsable>? _useFunction = null;

        public CustomPotion(PotionDefinition potion, uint stackCount, 
            params IAffectImmediately<IAffectableActor>[] effects) 
            : base(potion, stackCount, effects)
        {
            
        }

        public override void Use()
        {
            SetTargetFunction();

            if (CurrentStackCount > 0 && _useFunction is not null)
            {
                _useFunction.Invoke(this);
            }
        }

        public override void SetTargetFunction()
        {
            _useFunction = MyOwner.UseConsumable;
        }
    }
}


