using System;

namespace InventoryCoreLib
{

    public class PotionDefinition : UsableItemDefinition
    {
        public PotionDefinition(
             uint id,
             string name,
             string describtion,
             double weight_kg,
             uint price,
             BaseEffect?effect,
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
            else if (
                effect.Effect == ApplyableEffect.NotSet ||
                effect.Effect == ApplyableEffect.Repair ||
                effect.Effect == ApplyableEffect.RechargeItem ||
                effect.Effect == ApplyableEffect.Unlock)
            {
                throw new ArgumentException("Wrong effect category");
            }
            else
            {
                ItemEffect = effect;
            }

            Icon = iconRef;
            Miniature2D = miniature2DRef;
        }
    }
}
