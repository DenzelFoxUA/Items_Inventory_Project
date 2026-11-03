

using System;

namespace InventoryCoreLib
{
    public class ElementalEffect : BaseEffect
    {
        public string ElementName { get; protected init; } = "";

        public ElementalEffect(
            string elementName,
            uint damage,
            bool isPassive,
            uint duaration)
        {
            ElementName = elementName;
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

            if (obj is not ElementalEffect other)
                return false;

            return base.Equals(obj) && ElementName == other.ElementName;
        }

        public override bool Equals(object? obj) => Equals(obj as ElementalEffect);

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
