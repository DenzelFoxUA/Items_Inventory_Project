
using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public abstract class UsableItemInstance : BaseItemInstance
    {
        public UsableItem UsableItem => (UsableItem)Definition;

        public UsableItemInstance(BaseItem item, params IAffect<IAffectableCharacter>[]? effects) 
            : base(item, effects)
        {
            
        }

        public abstract override System.Collections.Generic.List<IAffect<IAffectableCharacter>>? Use();

        public override uint AddToStack(uint count)
        {
            if (!Definition.IsStackable)
                return count;

            if (CurrentStackCount >= Definition.MaxStackSize)
            {
                return count;
            }
            else if (count >= Definition.MaxStackSize - CurrentStackCount)
            {
                uint difference = Definition.MaxStackSize - CurrentStackCount;
                CurrentStackCount = Definition.MaxStackSize;
                return count - difference;
            }
            else
            {
                CurrentStackCount += count;
                return 0;
            }
        }

        public override uint RemoveFromStack(uint count)
        {
            if (!Definition.IsStackable)
                return 0;

            uint toRemove = Math.Min(count, CurrentStackCount);

            CurrentStackCount -= toRemove;

            return count - toRemove;
        }


    }
}
