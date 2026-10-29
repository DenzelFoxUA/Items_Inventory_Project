
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class BaseWeapon: DurableItem
    {
        public required AttackDefinition PrimaryAttack { get; init; }
        public AttackDefinition? SecondaryAttack { get; init; }

        public BaseWeapon(List<IEffect>? effects = null) : base(effects)
        {

        }
    }
}
