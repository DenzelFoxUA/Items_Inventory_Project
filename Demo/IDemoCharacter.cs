
using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IDemoCharacter : 
        IAffectableCharacter, 
        ICanUseItems<IUsable>,
        ICanUseEquipment<IEquipable>
    {

    }
}
