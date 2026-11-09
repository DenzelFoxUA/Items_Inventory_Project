
namespace InventoryCoreLib
{
    public class ScrollDefinition : UsableItem
    {

        public double MaxRange { get; protected init; }
        public uint Power { get; protected init; }

        public ScrollDefinition(
             uint id,
             string name,
             string describtion,
             double weight_kg,
             uint price,
             double maxRange,
             uint power,
             bool isSelfApplycable,
             string iconRef,
             string miniature2DRef)
        {

            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;
            Power = power;
            MaxRange = maxRange;

            Icon = iconRef;
            Miniature2D = miniature2DRef;

            IsSelfApplycable = isSelfApplycable;
        }

    }
}
