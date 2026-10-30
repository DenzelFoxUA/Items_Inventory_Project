
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public abstract class BaseWeapon: DurableItem
    {
        public AttackDefinition? PrimaryAttack { get; init; } = null;
        public AttackDefinition? SecondaryAttack { get; init; } = null;

        public BaseWeapon(List<IEffect>? effects = null) : base(effects)
        {

        }
    }
}
