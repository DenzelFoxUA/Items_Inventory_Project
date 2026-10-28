using System;

namespace InventoryCoreLib
{

    public abstract class WeaponInstance : DurableInstance, IAttack
    {

        public BaseWeapon Weapon => (BaseWeapon)Definition;

        public WeaponInstance(BaseWeapon _weapon) : base(_weapon)
        {
            
        }

        //IAttack

        public virtual AttackResult PrimaryAttack()
        {
            double conditionCoef = GetDurabilityCoefficient();

            uint damage = (uint)Math.Round(Weapon.PrimaryAttack.MaxDamage * conditionCoef);

            return new (Weapon.PrimaryAttack.AttackRange, damage);
        }

        public virtual AttackResult? SecondaryAttack()
        {
            
            if(Weapon.SecondaryAttack is not null)
            {

                double conditionCoef = GetDurabilityCoefficient();
                uint damage = (uint)Math.Round(Weapon.SecondaryAttack.MaxDamage * conditionCoef);
                return new(Weapon.SecondaryAttack.AttackRange, damage);
            }
            else
            {
                return null;
            }
        }
    }
}
