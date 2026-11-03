
using System;
using System.Collections.Generic;
using System.Linq;


namespace InventoryCoreLib
{
    public abstract class UsableItemDefinition : BaseItem
    {
        //public uint Volume { get; protected init; }

        //public System.Collections.Generic.List<BaseEffect>? ItemEffects { get; protected init; }

        protected abstract void ValidateEffects(params BaseEffect[]? effects);

        public IReadOnlyList<BaseEffect> ItemEffects { get; }

        protected UsableItemDefinition(params BaseEffect[] effects)
        {
            ItemEffects = Array.AsReadOnly(effects?.ToArray() ?? Array.Empty<BaseEffect>());
        }

        public override string ToString()
        {
            string itemEff = "";

            if (ItemEffects is null)
                itemEff = "no effect";
            else
            {
                foreach(var effect in ItemEffects)

                itemEff += effect.ToString() + "\n";
            }

            return base.ToString() + $"\n" + itemEff;
                
        }

        public override bool Equals(BaseItem? obj)
        {
            if (obj is null)
                return false;

            if (obj is not UsableItemDefinition other)
                return false;

            return base.Equals(obj) && ItemEffects == other.ItemEffects;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(base.GetHashCode());

            if (ItemEffects is null)
            {
                hash.Add(-1);
            }
            else
            {
                hash.Add(ItemEffects.Count);

                foreach (var effect in ItemEffects)
                    hash.Add(effect);
            }

            return hash.ToHashCode();
        }

    }

}
