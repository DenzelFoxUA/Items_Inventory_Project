
namespace InventoryCoreLib
{
    public abstract class DurableInstance : EquipableInstance, IDurable
    {
        protected DurableItem DurableDefinition 
        { 
            get => (DurableItem)Definition; 
        }

        public uint CurrentDurability { get; protected set; }

        public DurableInstance(DurableItem definition) : base(definition)
        {
            CurrentDurability = definition.MaxDurability;
        }

        public virtual void TakeDamage(uint damage)
        {
            if (DurableDefinition.IsIndestructible)
                return;

            if (damage >= CurrentDurability)
            {
                CurrentDurability = 0;
            }
            else
            {
                CurrentDurability -= damage;
            }
        }

        public double GetDurabilityCoefficient()
        {
            if (DurableDefinition.IsIndestructible)
                return 1.0;

            return DurableDefinition.MaxDurability != 0 ?
                (double)CurrentDurability / DurableDefinition.MaxDurability : 0;
        }

        public void Repair(uint points)
        {
            if (DurableDefinition.IsIndestructible)
                return;

            if (points >= DurableDefinition.MaxDurability - CurrentDurability)
                CurrentDurability = DurableDefinition.MaxDurability;
            else
                CurrentDurability += points;
        }
    }
}
