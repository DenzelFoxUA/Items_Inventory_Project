
using CharacterMainLib;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public interface IDemoCharacter : 
        IDemoActor<IAffectTemporary<IAffectableCharacter>, IAffectableCharacter>,
        IAffectableCharacter, 
        ICanUseItems<IOwnedUsable>,
        ICanUseEquipment<IOwnedEquipable>
    {
        public void UseConsumable(IOwnedUsable? consumable);
    }
}
