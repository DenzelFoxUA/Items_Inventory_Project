

using CharacterMainLib;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class HealthPotion : CustomPotionInstnce
    {
        public HealthPotion(PotionDefinition potion, uint duration_sec) 
            : base(potion, new RecoveryVitalEffect("Health",potion.Volume))
        {
            
        }
    }
}
