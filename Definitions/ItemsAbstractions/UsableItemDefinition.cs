
using System;

namespace InventoryCoreLib
{
    public abstract class UsableItemDefinition : BaseItem
    {
        //public uint Volume { get; protected init; }

        public BaseEffect? ItemEffect { get; protected init; }

        public override string ToString()
        {
            string itemEff = "";

            if (ItemEffect is null)
                itemEff = "no effect";
            else
                itemEff = ItemEffect.ToString();

            return base.ToString() + $"\n" + itemEff;
                
        }

        public override bool Equals(BaseItem? obj)
        {
            if (obj is null)
                return false;

            if (obj is not UsableItemDefinition other)
                return false;

            return base.Equals(obj) && ItemEffect == other.ItemEffect;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), 
                ItemEffect is not null ? ItemEffect.GetHashCode() : 0);
        }

    }

}
