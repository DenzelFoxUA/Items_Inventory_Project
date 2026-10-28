
namespace InventoryCoreLib
{

    public readonly record struct AttackResult(double maxRange, uint damage);

    public interface IAttack
    {
        public AttackResult PrimaryAttack();
        public AttackResult? SecondaryAttack();
    }
}
