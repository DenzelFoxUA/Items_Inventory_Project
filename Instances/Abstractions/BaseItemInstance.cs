
using System;

namespace InventoryCoreLib
{
    public abstract class BaseItemInstance
    {
        public BaseItem Definition { get; }

        public uint CurrentStackCount { get; protected set; } = 1;

        public BaseItemInstance(BaseItem definition)
        {
            if (definition is null)
                throw new ArgumentNullException(nameof(definition));

            Definition = definition;
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
            return Definition.GetHashCode();
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
    }
}
