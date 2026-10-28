using System;

namespace InventoryCoreLib
{
    

    public abstract class WeaponInstance : DurableInstance, IDurable, IAttack
    {

        protected BaseWeapon weapon;

        public WeaponInstance(BaseWeapon _weapon)
        {
            weapon = _weapon;
            CurrentDurability = _weapon.MaxDurability;
        }

        //IDurable

        public double GetDurabilityCoefficient()
        {
            return weapon.MaxDurability != 0 ? 
                (double)CurrentDurability / weapon.MaxDurability : 0;
        }

        public void Repair(uint points)
        {
            if (points >= weapon.MaxDurability - CurrentDurability)
                CurrentDurability = weapon.MaxDurability;
            else
                CurrentDurability += points;
        }

        //IAttack

        public virtual AttackResult PrimaryAttack()
        {
            double conditionCoef = GetDurabilityCoefficient();

            uint damage = (uint)Math.Round(weapon.PrimaryAttack.MaxDamage * conditionCoef);

            return new (weapon.PrimaryAttack.AttackRange, damage);
        }

        public virtual AttackResult? SecondaryAttack()
        {
            
            if(weapon.SecondaryAttack is not null)
            {

                double conditionCoef = GetDurabilityCoefficient();
                uint damage = (uint)Math.Round(weapon.SecondaryAttack.MaxDamage * conditionCoef);
                return new(weapon.SecondaryAttack.AttackRange, damage);
            }
            else
            {
                return null;
            }
        }
    }
}
