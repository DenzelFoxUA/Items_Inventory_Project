
namespace InventoryCoreLib
{

    //public readonly record struct AttackResult(double maxRange, uint damage);

    public interface IAttack
    {
        public uint PrimaryAttack(double distanceToTarget);
        public uint? SecondaryAttack(double distanceToTarget);
    }
}
