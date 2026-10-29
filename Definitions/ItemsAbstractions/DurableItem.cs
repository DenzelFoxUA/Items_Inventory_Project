
namespace InventoryCoreLib
{
    public abstract class DurableItem: EquipableItem
    {
        public uint MaxDurability { get; init; } = 0;

        public bool IsIndestructible { get; init; } = false;
    }
}
