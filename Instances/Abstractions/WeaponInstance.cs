using System;
using System.Collections.Generic;

namespace InventoryCoreLib
{

    public abstract class WeaponInstance : DurableInstance, IAttack
    {
        private BaseWeapon Weapon => (BaseWeapon)Definition;

        public WeaponInstance(BaseWeapon _weapon) :
            base(_weapon)
        {
            
        }

        //IAttack

        public virtual uint PrimaryAttack(double distanceToTarget)
        {
            if (distanceToTarget <= Weapon.PrimaryAttack.AttackRange)
            {
                double conditionCoef = GetDurabilityCoefficient();

                uint damage = (uint)Math.Round(Weapon.PrimaryAttack.MaxDamage * conditionCoef);

                return damage;
            }

            return 0;
        }

        public virtual uint? SecondaryAttack(double distanceToTarget)
        {
            if (Weapon.SecondaryAttack is null)
                return null;

            if (distanceToTarget <= Weapon.SecondaryAttack.AttackRange)
            {
                double conditionCoef = GetDurabilityCoefficient();
                uint damage = (uint)Math.Round(Weapon.SecondaryAttack.MaxDamage * conditionCoef);
                return damage;
            }

            return 0;

        }
    }
}
