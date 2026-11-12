

using CharacterMainLib;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class HealthPotion : CustomPotion
    {
        public HealthPotion(PotionDefinition potion, uint stackCount, uint duration_sec) 
            : base(potion, stackCount, new ImmdRecoveryVitalEffect("Restore HP", "Health",potion.Volume))
        {
            
        }
    }
}
