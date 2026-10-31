
namespace InventoryCoreLib
{
    public class Potion : UsableItemInstance
    {

        public PotionDefinition PotionDef => (PotionDefinition)Definition;

        public Potion(PotionDefinition potion) : base(potion)
        {

        }

        public override ForceEffect? Use()
        {
            if (CurrentStackCount > 0)
            {
                CurrentStackCount--;

                if (PotionDef.ItemEffect is null)
                    return null;

                return new ForceEffect
                {
                    ApplyableForce = PotionDef.ItemEffect.Effect,
                    Duration = PotionDef.ItemEffect.EffectDuration,
                    Power = PotionDef.ItemEffect.PowerValue
                };
            }

            return null;
        }
    }
}
