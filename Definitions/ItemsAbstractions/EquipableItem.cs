using System.Collections.Generic;

namespace InventoryCoreLib
{
    public enum WearableItemCategory
    {
        BodyArmor = 0,
        Head = 1,
        Boots = 2,
        Gloves,
        OneHanded,
        LeftHandOnly,
        RightHandOnly,
        TwoHanded,
        Amulet,
        Ring = 9
    }

    public abstract class EquipableItem : BaseItem
    {

        public WearableItemCategory EqupmentCategory { get; protected init; }

        public IReadOnlyList<BaseEffect> Effects { get; }
        
        public uint LevelRequired { get; protected init; } = 0;

        public EquipableItem(List<BaseEffect>? effects = null)
        {
            List<BaseEffect> specialEffects = effects is null ?
                          new List<BaseEffect>() :
                          new List<BaseEffect>(effects);

            Effects = specialEffects.AsReadOnly();
        }
    }
}
