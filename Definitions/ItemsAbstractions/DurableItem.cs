
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class DurableItem: EquipableItem
    {
        public uint MaxDurability { get; protected init; } = 0;

        public bool IsIndestructible { get; protected init; } = false;

        public DurableItem(List<BaseEffect>? effects = null) : base(effects)
        {

        }
    }
}
