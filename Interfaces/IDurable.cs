
namespace InventoryCoreLib
{
    public interface IDurable
    {
        public double GetDurabilityCoefficient();

        public void Repair(uint points);

        public void TakeDamage(uint damage);

    }
}
