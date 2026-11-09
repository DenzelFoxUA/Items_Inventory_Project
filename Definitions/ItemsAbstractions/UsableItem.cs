
using System;
using System.Collections.Generic;
using System.Linq;


namespace InventoryCoreLib
{
    public abstract class UsableItem : BaseItem
    {
        public bool IsSelfApplycable { get; protected init; }

        public override bool Equals(BaseItem? obj)
        {
            if (obj is null)
                return false;

            if (obj is not UsableItem other)
                return false;

            return base.Equals(obj) && IsSelfApplycable == other.IsSelfApplycable;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), IsSelfApplycable);
        }

    }

}
