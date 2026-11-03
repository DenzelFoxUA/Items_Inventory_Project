
using System;
using System.Linq;

namespace InventoryCoreLib
{
    public class PhysicalEffect : BaseEffect
    {
        public string Type { get; protected init; } = "";

        public PhysicalEffect(
            string typeName,
            uint damage,
            bool isPassive,
            uint duaration)
        {
            if (EffectsStatics.PYSICAL_EFFECTS_TYPES.Contains(typeName))
                Type = typeName;


            EffectCategory = EffectCategory.Elemental;
            PowerValue = damage;
            IsPassive = isPassive;
            EffectDuration = duaration;
        }

        //equals

        public override bool Equals(BaseEffect? obj)
        {
            if (obj is null)
                return false;

            if (obj is not PhysicalEffect other)
                return false;

            return base.Equals(obj) && Type == other.Type;
        }

        public override bool Equals(object? obj) => Equals(obj as PhysicalEffect);

        public override int GetHashCode()
        {
            return HashCode.Combine(EffectCategory, PowerValue, EffectDuration, IsPassive);
        }

        public override void Apply()
        {
            throw new NotImplementedException();
        }
    }
}
