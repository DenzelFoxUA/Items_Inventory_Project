
using System;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class BaseArmor: DurableItem
    {
        public uint MaxDefence { get; protected init; } = 0;

        public override bool Equals(BaseItem? obj)
        {
            if (obj is null)
                return false;

            if (obj is not BaseArmor other)
                return false;

            return base.Equals(obj) && MaxDefence == other.MaxDefence;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), MaxDefence);
        }
    }
}
