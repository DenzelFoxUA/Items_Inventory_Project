
using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{

    public abstract class BaseItemInstance
    {

        protected BaseItem? _itemDefinition;

        public BaseItem? Definition { get => _itemDefinition; }

        protected IDemoCharacter? _owner;
        protected IAffectableActor? _target;

        public BaseItemInstance(BaseItem definition)
        {
            if (definition is null)
                throw new ArgumentNullException(nameof(definition));

            _itemDefinition = definition;
            _owner = null;
            _target = null;
        }

        #region Equals

        public bool Equals(BaseItemInstance? other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Equals(this.Definition, other.Definition) &&
                Equals(this._owner, other._owner) &&
                Equals(this._target, other._target);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as BaseItemInstance);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(_itemDefinition);

            hash.Add(_owner);

            hash.Add(_target);

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
