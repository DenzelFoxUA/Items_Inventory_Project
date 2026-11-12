

namespace InventoryCoreLib
{
    public interface IReducePhysicalDamage
    {
        public void ReduceDamage(ref uint damageIncome);
        public uint GetDefencePoints();
    }
}
