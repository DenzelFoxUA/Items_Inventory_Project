
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class BaseWeapon: DurableItem
    {
        public AttackDefinition? PrimaryAttack { get; protected init; } = null;
        public AttackDefinition? SecondaryAttack { get; protected init; } = null;

        public BaseWeapon(List<IEffect>? effects = null) : base(effects)
        {

        }
    }
}
