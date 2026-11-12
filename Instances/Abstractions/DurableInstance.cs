
using CharacterMainLib;
using System;
using System.Data;

namespace InventoryCoreLib
{
    public abstract class DurableInstance<TEffect,TTarget> : 
        EquipableInstance<TEffect,TTarget>, IDurable
        where TEffect : class, IAffect<TTarget>
        where TTarget : class, IAffectable
    {
        private DurableItem Item
        {
            get 
            {
                if (Definition is null)
                    throw new ObjectNotInitializedException(nameof(Definition));
                
                return (DurableItem)Definition!; 
            }
        }

        public uint CurrentDurability { get; protected set; }

        public DurableInstance(DurableItem definition, 
            params TEffect[]?effects) :
            base(definition,effects)
        {
            CurrentDurability = definition.MaxDurability;
        }

        public virtual void TakeDamage(uint damage)
        {
            if (Item.IsIndestructible)
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
            if (Item.IsIndestructible)
                return 1.0;

            return Item.MaxDurability != 0 ?
                (double)CurrentDurability / Item.MaxDurability : 0;
        }

        public void Repair(uint points)
        {
            if (Item.IsIndestructible)
                return;

            if (points >= Item.MaxDurability - CurrentDurability)
                CurrentDurability = Item.MaxDurability;
            else
                CurrentDurability += points;
        }
    }
}
