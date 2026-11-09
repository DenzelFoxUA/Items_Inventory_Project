
namespace InventoryCoreLib
{
    public class MagicStoneDefinition : UsableItem
    {
        public uint ChargePower { get; protected init; } 

        public MagicStoneDefinition(
             uint id,
             string name,
             uint chargePower,
             string describtion,
             double weight_kg,
             uint price,
             string iconRef,
             string miniature2DRef)
        {

            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;
            ChargePower = chargePower;
            Icon = iconRef;
            Miniature2D = miniature2DRef;

            IsSelfApplycable = false;
        }

    }
}
