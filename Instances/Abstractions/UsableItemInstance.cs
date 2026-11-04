
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{
    public abstract class UsableItemInstance : BaseItemInstance
    {
        public UsableItem UsableItem => (UsableItem)Definition;

        public UsableItemInstance(UsableItem item, params BaseEffect[]? effects) : base(item, effects)
        {
            
        }

        public abstract override System.Collections.Generic.List<BaseEffect>? Use();

        public virtual void AddToStack(UsableItemInstance? other)
        {

            if (other is null)
                throw new ArgumentNullException("Other item is null");

            if (ReferenceEquals(this, other))
                return;

            if (!Definition.Equals(other.Definition))
                throw new InvalidOperationException("Different item definitions.");

            if (!Definition.IsStackable)
                throw new InvalidOperationException("Item is not stackable.");

            uint stackSum = other.CurrentStackCount + CurrentStackCount;

            if (stackSum >= UsableItem.MaxStackSize)
            {
                uint difference = stackSum - UsableItem.MaxStackSize;

                CurrentStackCount = UsableItem.MaxStackSize;
                other.CurrentStackCount = difference;
            }
            else
            {
                CurrentStackCount += other.CurrentStackCount;
                other.CurrentStackCount = 0;
            }
        }

        
    }
}
