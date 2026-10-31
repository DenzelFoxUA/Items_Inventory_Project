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
