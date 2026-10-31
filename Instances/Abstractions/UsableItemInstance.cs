
using System;

namespace InventoryCoreLib
{
    public abstract class UsableItemInstance : BaseItemInstance, IUsable
    {
        public UsableItemDefinition UsableItem => (UsableItemDefinition)Definition;

        public UsableItemInstance(UsableItemDefinition item) : base(item)
        { }

        public virtual uint Use()
        {
            if (CurrentStackCount > 0)
            {
                CurrentStackCount--;
                return UsableItem.Volume;
            }

            return 0;
        }

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
