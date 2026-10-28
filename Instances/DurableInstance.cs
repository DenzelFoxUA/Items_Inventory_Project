

namespace InventoryCoreLib
{
    public abstract class DurableInstance
    {
        public uint CurrentDurability { get; protected set; }
        public bool IsIndestructible { get; protected set; }

        public virtual void TakeDamage(uint damage)
        {
            if (damage >= CurrentDurability)
            {
                CurrentDurability = 0;
            }
            else
            {
                CurrentDurability -= damage;
            }
        }
    }
}
