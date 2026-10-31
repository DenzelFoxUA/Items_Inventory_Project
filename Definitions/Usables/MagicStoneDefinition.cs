

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
             BaseEffect? effect,
             string iconRef,
             string miniature2DRef)
        {
            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;

            if (effect is null)
            {
                throw new ArgumentNullException("Effect is null");
            }

            if (effect.Effect == ApplyableEffect.RechargeItem)
            {
                ItemEffect = effect;
            }
            else
            {
                throw new ArgumentException("Wrong effect category");
            }

            Icon = iconRef;
            Miniature2D = miniature2DRef;
        }
    }
}
