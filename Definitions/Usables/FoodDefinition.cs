using System;

namespace InventoryCoreLib
{
    public enum FoodCategory
    {
        NotSet = 0,
        ReadyMeal = 1,
        RawMeat = 2,
        Vegetable,
        Fruit,
        Mushroom,
        PureWater,
        Drink,
        Alcohol
    }

    public class FoodDefinition: UsableItemDefinition
    {
        public FoodCategory Category { get; protected init; } = FoodCategory.NotSet;

        public FoodDefinition(
             uint id,
             string name,
             FoodCategory cat,
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
            Category = cat;
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
