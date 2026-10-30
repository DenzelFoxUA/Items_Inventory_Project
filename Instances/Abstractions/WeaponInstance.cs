using System;

namespace InventoryCoreLib
{
    public abstract class WeaponInstance : DurableInstance, IAttack
    {
        private BaseWeapon Weapon => (BaseWeapon)Definition;

        public WeaponInstance(BaseWeapon _weapon) :
            base(_weapon)
        {
            
        }

        private uint BaseAttackFunc(uint weaponDamage)
        {
            double conditionCoef = GetDurabilityCoefficient();

            uint damage = (uint)Math.Round(weaponDamage * conditionCoef);

            foreach (var effect in Weapon.Effects)
            {
                if (!effect.IsPassive)
                {
                    var effectResult = effect.Apply();

                    //temp
                    Console.WriteLine($"+{effectResult.Power} damage of {effectResult.ApplyableForce}");
                    //

                    damage += effectResult.Power;

                }
            }

            return damage;

        }

        //IAttack
        public virtual uint PrimaryAttack(double distanceToTarget)
        {
            if (Weapon.PrimaryAttack == null)
                throw new ArgumentNullException("ERR::Primary attack not set!");

            if (distanceToTarget <= Weapon.PrimaryAttack.AttackRange)
            {
                return BaseAttackFunc(Weapon.PrimaryAttack.MaxDamage);
            }

            return 0;
        }

        public virtual uint? SecondaryAttack(double distanceToTarget)
        {
            if (Weapon.SecondaryAttack is null)
                return null;

            if (distanceToTarget <= Weapon.SecondaryAttack.AttackRange)
            {
                return BaseAttackFunc(Weapon.SecondaryAttack.MaxDamage);
            }

            return 0;

        }
    }
}
