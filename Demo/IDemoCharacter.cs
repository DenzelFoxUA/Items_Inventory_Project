
using CharacterMainLib;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public interface IDemoCharacter : 
        ICollectEffects<IAffectableCharacter>,
        IAffectableCharacter, 
        ICanUseItems<IOwnedUsable>,
        ICanUseEquipment<IOwnedEquipable>
    {
        public void UseConsumable(IOwnedUsable? consumable);
    }
}
