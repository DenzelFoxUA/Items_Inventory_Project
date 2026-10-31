using System;

namespace InventoryCoreLib
{
    public class FoodDefinition: UsableItemDefinition
    {

        public FoodDefinition(
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

            if(effect.Effect == ApplyableEffect.Heal ||
                effect.Effect == ApplyableEffect.Poison ||
                effect.Effect == ApplyableEffect.RestoreStamina)
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
