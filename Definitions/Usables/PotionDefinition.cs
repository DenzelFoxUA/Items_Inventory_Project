
namespace InventoryCoreLib
{

    public class PotionDefinition : UsableItem
    {
        public uint Volume { get; protected init; }

        public PotionDefinition(
             uint id,
             string name,
             string describtion,
             uint volume,
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
            Volume = volume;
            IsStackable = true;
            MaxStackSize = 5;
            Icon = iconRef;
            Miniature2D = miniature2DRef;
        }

    }
}
