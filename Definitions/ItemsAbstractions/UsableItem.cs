
using System;
using System.Collections.Generic;
using System.Linq;


namespace InventoryCoreLib
{
    public abstract class UsableItem : BaseItem
    {
        

        ////public System.Collections.Generic.List<BaseEffect>? ItemEffects { get; protected init; }

        //protected abstract void ValidateEffects(params BaseEffect[]? effects);

        //public IReadOnlyList<BaseEffect> ItemEffects { get; }


        public override bool Equals(BaseItem? obj)
        {
            if (obj is null)
                return false;

            if (obj is not UsableItem other)
                return false;

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

}
