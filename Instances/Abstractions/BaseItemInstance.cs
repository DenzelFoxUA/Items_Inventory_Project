
using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace InventoryCoreLib
{
    public abstract class BaseItemInstance : IUsable
    {
        public BaseItem Definition { get; }

        public uint CurrentStackCount { get; protected set; } = 1;

        public IReadOnlyList<BaseEffect> Effects { get; }

        protected abstract void ValidateEffects(params BaseEffect[]? effects);



        public BaseItemInstance(BaseItem definition, params BaseEffect[]? effects)
        {
            if (definition is null)
                throw new ArgumentNullException(nameof(definition));

            Definition = definition;

            Effects = Array.AsReadOnly(effects?.ToArray() ?? Array.Empty<BaseEffect>());
        }

        public bool Equals(BaseItemInstance? other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return this.Definition.Equals(other.Definition);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BaseItemInstance);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(base.GetHashCode());

            if (Effects is null)
            {
                hash.Add(-1);
            }
            else
            {
                hash.Add(Effects.Count);

                foreach (var effect in Effects)
                    hash.Add(effect);
            }

            return hash.ToHashCode();
        }

        public virtual object ?Use()
        {
            return null;
        }

        public static bool operator == (BaseItemInstance? one, BaseItemInstance? other)
        {

            if (ReferenceEquals(one, other)) return true;

            if (one is null || other is null)
                return false;

            return one.Equals(other);
        }

        public static bool operator != (BaseItemInstance one, BaseItemInstance other)
        {
            return !(one == other);
        }

        public override string ToString()
        {
            string itemEff = "";

            if (Effects is null)
                itemEff = "no effect";
            else
            {
                foreach (var effect in Effects)

                    itemEff += effect.ToString() + "\n";
            }

            return base.ToString() + $"\n" + itemEff;

        }
    }
}
