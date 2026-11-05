using System;
using CharacterMainLib;
namespace InventoryCoreLib
{
    //public enum EffectCategory
    //{
    //    Physical = 0,
    //    Elemental = 1,
    //    Magic,
    //    Recovery,
    //    Mining,
    //    Utility
    //}

    public interface IAffect<T> where T : class, IAffectable
    {
        public void Apply();

        public void SetTarget(T? target);
    }

    public abstract class BaseEffect<T> : IAffect<T>
        where T : class, IAffectable
    {
        public T? Target { get; protected set; }

        public uint EffectDuration { get; protected init; } = 0;

        public uint PowerValue { get; protected init; } = 0;

        public bool IsPassive { get; protected init; } = false;

        //methods

        public abstract void Apply();

        public virtual void SetTarget(T? target)
        {
            Target = target;
        }

        //equality

        public virtual bool Equals(BaseEffect<T>? other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return PowerValue.Equals(other.PowerValue) &&
                EffectDuration.Equals(other.EffectDuration) &&
                IsPassive.Equals(other.IsPassive);
        }

        public override bool Equals(object? obj) => Equals(obj as BaseEffect<T>);

        public override int GetHashCode()
        {
            return HashCode.Combine(PowerValue, EffectDuration, IsPassive);
        }

        public static bool operator ==(BaseEffect<T>? one, BaseEffect<T>? other)
        {
            if (ReferenceEquals(one, other))
                return true;

            if (one is null || other is null)
                return false;

            return one.Equals(other);
        }
        public static bool operator !=(BaseEffect<T>? one, BaseEffect<T>? other)
        {
            return !(one == other);
        }
    }
}
