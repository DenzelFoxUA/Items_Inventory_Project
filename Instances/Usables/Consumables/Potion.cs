
namespace InventoryCoreLib
{
    public class Potion : UsableItemInstance
    {

        public PotionDefinition PotionDef => (PotionDefinition)Definition;

        public Potion(PotionDefinition potion) : base(potion)
        {

        }
        
        public uint GetEffectDuration()
        {
            return PotionDef.EffectDuration;
        }
    }
}
