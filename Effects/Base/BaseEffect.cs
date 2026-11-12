using System;
using CharacterMainLib;
namespace InventoryCoreLib
{

    public abstract class BaseEffect<T, P> : IAffect<T>
        where T : class, IAffectable
    {
        public string Name { get; protected init; } = "NONAME";

        public T? Target { get; protected set; }

        public P PowerValue { get; protected init; } = default!;

        protected bool _isApplied = false;

        //methods

        public abstract void Apply();

        public virtual void Remove() { }

        public virtual void SetTarget(T? target)
        {
            if (_isApplied)
                throw new EffectStateException(Name);

            Target = target;
        }

        //equality

        public virtual bool Equals(BaseEffect<T, P>? other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Name.Equals(other.Name) && PowerValue!.Equals(other.PowerValue);
        }

        public override bool Equals(object? obj) => Equals(obj as BaseEffect<T, P>);

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, PowerValue);
        }

        public static bool operator ==(BaseEffect<T, P>? one, BaseEffect<T, P>? other)
        {
            if (ReferenceEquals(one, other))
                return true;

            if (one is null || other is null)
                return false;

            return one.Equals(other);
        }
        public static bool operator !=(BaseEffect<T, P>? one, BaseEffect<T, P>? other)
        {
            return !(one == other);
        }
    }
}
