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
        DualWelding,
        Amulet,
        Ring
    }

    public abstract class EquipableItem : BaseItem
    {
        public WearableItemCategory Category { get; init; } = WearableItemCategory.NOTSET;
        public uint LevelRequired { get; init; } = 0;
    }
}
