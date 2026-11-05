
using CharacterMainLib;

namespace InventoryCoreLib
{
    public class ManaPotion : CustomPotionInstnce
    {
        public ManaPotion(PotionDefinition potion, uint duration_sec)
            : base(potion, new RecoveryVitalEffect("Mana", potion.Volume))
        {
        }
    }
}
