

using System;

namespace InventoryCoreLib
{
    public class MagicStoneDefinition : UsableItemDefinition
    {
        public MagicStoneDefinition(
             uint id,
             string name,
             string describtion,
             double weight_kg,
             uint price,
             string iconRef,
             string miniature2DRef,
             params BaseEffect[] effects) : base(effects)
        {

            ValidateEffects(effects);

            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;

            Icon = iconRef;
            Miniature2D = miniature2DRef;
        }

        protected override void ValidateEffects(params BaseEffect[]? effects)
        {
            if (effects is null)
                throw new ArgumentNullException(nameof(effects));

            if (effects.Length == 0)
                throw new ArgumentException("Effects cannot be empty", nameof(effects));

        }

    }
}
