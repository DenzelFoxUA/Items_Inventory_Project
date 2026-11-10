
using CharacterMainLib;
using System;


namespace InventoryCoreLib
{

    public abstract class BaseItemInstance
    {
        private BaseItem? _itemDefinition;

        public BaseItem? Definition { get => _itemDefinition; }

        protected IDemoCharacter? _owner;

        #region [ CTOR ]

        public BaseItemInstance(BaseItem definition)
        {
            if (definition is null)
                throw new ArgumentNullException(nameof(definition));

            _itemDefinition = definition;
            _owner = null;
        }

        #endregion

        #region Equals

        public bool Equals(BaseItemInstance? other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Equals(this.Definition, other.Definition);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BaseItemInstance);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(_itemDefinition);

            return hash.ToHashCode();
        }

        public static bool? operator ==(BaseItemInstance? one, BaseItemInstance? other)
        {

            if (ReferenceEquals(one, other)) return true;

            if (one is null || other is null)
                return false;

            return one.Equals(other);
        }

        public static bool? operator !=(BaseItemInstance one, BaseItemInstance other)
        {
            return !(one == other);
        }

        #endregion //equals

        public abstract void SetTargetFunction();
    }
}
