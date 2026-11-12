
using CharacterMainLib;

namespace InventoryCoreLib
{
    public class ManaPotion : CustomPotion
    {
        public ManaPotion(PotionDefinition potion, uint stackCount, uint duration_sec)
            : base(potion, stackCount, new ImmdRecoveryVitalEffect("Restore mana", "Mana", potion.Volume))
        {
        }
    }
}
