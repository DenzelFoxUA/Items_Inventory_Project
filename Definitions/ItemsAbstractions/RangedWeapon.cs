
using System;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class RangedWeapon : BaseWeapon
    {
        public uint ProjectilesCapacity { get; protected init; }

        public override bool Equals(BaseItem? obj)
        {
            if (obj is null)
                return false;

            if (obj is not RangedWeapon other)
                return false;

            return base.Equals(obj) && ProjectilesCapacity == other.ProjectilesCapacity;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), ProjectilesCapacity);
        }
    }
}
