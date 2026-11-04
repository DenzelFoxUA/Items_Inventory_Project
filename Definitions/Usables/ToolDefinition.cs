
namespace InventoryCoreLib
{
    public class ToolDefinition : UsableItem
    {
        public uint MaxNumberOfUses { get; protected init; }

        public ToolDefinition(
             uint id,
             string name,
             string describtion,
             double weight_kg,
             uint price,
             uint numOfUses,
             string iconRef,
             string miniature2DRef)
        {

            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;

            MaxNumberOfUses = numOfUses;

            Icon = iconRef;
            Miniature2D = miniature2DRef;
        }

    }
}
