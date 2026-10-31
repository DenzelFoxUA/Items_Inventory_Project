
using System;

namespace InventoryCoreLib
{
    public abstract class UsableItemDefinition : BaseItem
    {
        public uint Volume { get; protected init; }

        public override string ToString()
        {
            return base.ToString() + $"\n" +
                $"Volume: {Volume}";
        }

        public bool Equals(UsableItemDefinition? obj)
        {
            if (obj is null)
                return false;

            return base.Equals(obj) && this.Volume == obj.Volume;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Volume);
        }

    }

}
