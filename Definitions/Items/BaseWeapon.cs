
namespace InventoryCoreLib
{
    public abstract class BaseWeapon: DurableItem
    {
        public required AttackDefinition PrimaryAttack { get; init; }
        public AttackDefinition? SecondaryAttack { get; init; }
    }
}
