
namespace InventoryCoreLib
{
    public interface IAttack
    {
        public uint PrimaryAttack(double distanceToTarget);
        public uint? SecondaryAttack(double distanceToTarget);
    }
}
