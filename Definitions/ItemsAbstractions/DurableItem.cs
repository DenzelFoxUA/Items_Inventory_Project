
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class DurableItem: EquipableItem
    {
        public uint MaxDurability { get; init; } = 0;

        public bool IsIndestructible { get; init; } = false;

        public DurableItem(List<IEffect>? effects = null) : base(effects)
        {

        }
    }
}
