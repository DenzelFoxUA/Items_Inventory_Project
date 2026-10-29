
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class BaseArmor: DurableItem
    {
        public uint MaxDefence { get; init; } = 0;

        public BaseArmor(List<IEffect>? effects = null) : base(effects)
        {

        }
    }
}
