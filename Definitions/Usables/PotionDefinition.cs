
namespace InventoryCoreLib
{

    public class PotionDefinition : UsableItemDefinition
    {

        public uint EffectDuration { get; protected init; } = 1;
        public bool IsPoisoness { get; protected init; } = false;

        public PotionDefinition(
             uint id,
             string name,
             string describtion,
             uint volume,
             double weight_kg,
             uint price,
             uint duration_sec,
             bool isPoisoness,
             string iconRef,
             string miniature2DRef)
        {
            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Volume = volume;
            Price = price;

            EffectDuration = duration_sec;
            IsPoisoness = isPoisoness; 

            Icon = iconRef;
            Miniature2D = miniature2DRef;
        }
    }
}
