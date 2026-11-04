
using System.Linq;

namespace InventoryCoreLib
{
    public class Potion : UsableItemInstance
    {

        public PotionDefinition PotionDef => (PotionDefinition)Definition;

        public Potion(PotionDefinition potion, params BaseEffect[] effects) : base(potion,effects)
        {

        }

        public override System.Collections.Generic.List<BaseEffect>? Use()
        {
            if (CurrentStackCount > 0)
            {
                CurrentStackCount--;

                return ItemEffects.ToList();
            }

            return null;
        }

        protected override void ValidateEffects(params BaseEffect[]? effects)
        {
            throw new System.NotImplementedException();
        }
    }
}
