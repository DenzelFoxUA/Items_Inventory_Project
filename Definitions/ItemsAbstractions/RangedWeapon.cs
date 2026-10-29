
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class RangedWeapon : BaseWeapon
    {
        public uint ProjectilesCapacity { get; init; }

        public RangedWeapon(List<IEffect>? effects = null) : base(effects)
        {

        }
    }
}
