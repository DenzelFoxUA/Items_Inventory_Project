
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

            //ValidateEffects(effects);

            Id = id;
            Name = name;
            Descriprion = describtion;
            Weight = weight_kg;
            Price = price;
            Volume = volume;
            Icon = iconRef;
            Miniature2D = miniature2DRef;
        }

        //protected override void ValidateEffects(params BaseEffect[]? effects)
        //{
        //    if (effects is null)
        //        throw new ArgumentNullException(nameof(effects));

        //    if (effects.Length == 0)
        //        throw new ArgumentException("Effects cannot be empty", nameof(effects));

        //}
    }
}
