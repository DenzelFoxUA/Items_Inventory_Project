using System;
using CharacterMainLib;
namespace InventoryCoreLib
{
    public enum EffectCategory
    {
        Physical = 0,
        Elemental = 1,
        Magic,
        Recovery,
        Mining,
        Utility
    }

    public abstract class BaseEffect : IEquatable<BaseEffect>
    {
        public EffectCategory EffectCategory { get; protected init; } = EffectCategory.Physical;

        public uint EffectDuration { get; protected init; } = 0;

        public uint PowerValue { get; protected init; } = 0;

        public bool IsPassive { get; protected init; } = false;

        //methods

        public override string ToString()
        {
            return $"Name: {EffectCategory}\n" +
                $"Power: {PowerValue} points\n";
        }

        public abstract void Apply();

        public abstract void SetTarget<T>(T? target) where T : class, IAffectable;

        //equality

        public virtual bool Equals(BaseEffect? other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return
                EffectCategory.Equals(other.EffectCategory) &&
                PowerValue.Equals(other.PowerValue) &&
                EffectDuration.Equals(other.EffectDuration) &&
                IsPassive.Equals(other.IsPassive);
        }

        public override bool Equals(object? obj) => Equals(obj as BaseEffect);

        public override int GetHashCode()
        {
            return HashCode.Combine(EffectCategory, PowerValue, EffectDuration, IsPassive);
        }

        public static bool operator ==(BaseEffect? one, BaseEffect? other)
        {
            if (ReferenceEquals(one, other))
                return true;

            if (one is null || other is null)
                return false;

            return one.Equals(other);
        }
        public static bool operator !=(BaseEffect? one, BaseEffect? other)
        {
            return !(one == other);
        }
    }
}
