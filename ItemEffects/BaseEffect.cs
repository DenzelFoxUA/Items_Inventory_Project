using System;

namespace InventoryCoreLib
{

    public class BaseEffect : IEffect, IEquatable<BaseEffect>
    {

        public string Name { get; protected init; } = "";

        public ApplyableEffect Effect { get; protected init; } = ApplyableEffect.NotSet;

        public uint EffectDuration { get; protected init; }

        public uint PowerValue { get; protected init; } = 0;

        public string Describtion { get; protected init; } = "";

        public bool IsPassive { get; protected init; } = false;


        public BaseEffect(
            string name,
            uint damage,
            string describtion,
            ApplyableEffect force,
            bool isPassive,
            uint duaration)
        {
            Name = name;
            Effect = force;
            PowerValue = damage;
            Describtion = describtion;
            IsPassive = isPassive;
            EffectDuration = duaration;
        }


        //methods
        public virtual ForceEffect Apply()
        {
            return new ForceEffect
            {
                ApplyableForce = Effect,
                Duration = EffectDuration,
                Power = PowerValue
            };
        }

        public override string ToString()
        {
            return
                $"Name: {Name}\n" +
                $"Power: {PowerValue} points\n" +
                $"Describtion: {Describtion}\n";
        }

        //equality

        public bool Equals(BaseEffect? other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return
                this.Name.Equals(other.Name) &&
                Effect.Equals(other.Effect) &&
                PowerValue.Equals(other.PowerValue) &&
                EffectDuration.Equals(other.EffectDuration) &&
                IsPassive.Equals(other.IsPassive);
        }

        public override bool Equals(object? obj) => Equals(obj as BaseEffect);

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Effect, PowerValue, EffectDuration);
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
