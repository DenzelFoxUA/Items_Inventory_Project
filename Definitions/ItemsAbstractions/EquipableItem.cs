using System.Collections.Generic;

namespace InventoryCoreLib
{
    public enum WearableItemCategory
    {
        NOTSET = 0,
        BodyArmor = 1,
        Head = 2,
        Boots,
        Gloves,
        OneHanded,
        LeftHandOnly,
        RightHandOnly,
        TwoHanded,
        Amulet,
        Ring
    }

    public abstract class EquipableItem : BaseItem
    {

        public WearableItemCategory EqupmentCategory { get; protected init; } = WearableItemCategory.NOTSET;

        public IReadOnlyList<IEffect> Effects { get; }
        
        public uint LevelRequired { get; protected init; } = 0;

        public EquipableItem(List<IEffect>? effects = null)
        {
            List<IEffect> specialEffects = effects is null ?
                          new List<IEffect>() :
                          new List<IEffect>(effects);

            Effects = specialEffects.AsReadOnly();
        }
    }
}
