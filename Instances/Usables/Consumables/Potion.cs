
using System.Linq;

namespace InventoryCoreLib
{
    public class Potion : UsableItemInstance
    {

        public PotionDefinition PotionDef => (PotionDefinition)Definition;

        public Potion(PotionDefinition potion) : base(potion)
        {

        }

        public override System.Collections.Generic.List<BaseEffect>? Use()
        {
            if (CurrentStackCount > 0)
            {
                CurrentStackCount--;

                return PotionDef.ItemEffects.ToList();
            }

            return null;
        }
    }
}
