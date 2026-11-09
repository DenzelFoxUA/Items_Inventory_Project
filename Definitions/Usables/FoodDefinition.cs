
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

    public class FoodDefinition: UsableItem
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
             string miniature2DRef)
        {

            Id = id;
            Name = name;
            Category = cat;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;
            IsSelfApplycable = true;
            Icon = iconRef;
            Miniature2D = miniature2DRef;
        }

    }
}
