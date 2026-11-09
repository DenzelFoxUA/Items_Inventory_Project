
using System;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class DurableItem: EquipableItem
    {
        public uint MaxDurability { get; protected init; } = 0;

        public bool IsIndestructible { get; protected init; } = false;

        public override bool Equals(BaseItem? obj)
        {
            if (obj is null)
                return false;

            if (obj is not DurableItem other)
                return false;

            return base.Equals(obj) && 
                MaxDurability == other.MaxDurability &&
                IsIndestructible == other.IsIndestructible;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), MaxDurability, IsIndestructible);
        }
    }
}
