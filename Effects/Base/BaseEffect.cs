using System;
using System.Numerics;
using CharacterMainLib;
namespace InventoryCoreLib
{

    public interface IAffect<in T> where T : IAffectable
    {
        public void Apply();

        public void Remove();

        public void SetTarget(T? target);
    }

    public abstract class BaseEffect<T, P> : IAffect<T>
        where T : class, IAffectable
        where P : INumber<P>
    {
        public T? Target { get; protected set; }

        public P PowerValue { get; protected init; }

        //methods

        public abstract void Apply();

        public virtual void Remove() { }

        public virtual void SetTarget(T? target)
        {
            Target = target;
        }

        //equality

        public virtual bool Equals(BaseEffect<T, P>? other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return PowerValue.Equals(other.PowerValue);
        }

        public override bool Equals(object? obj) => Equals(obj as BaseEffect<T, P>);

        public override int GetHashCode()
        {
            return HashCode.Combine(PowerValue);
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
