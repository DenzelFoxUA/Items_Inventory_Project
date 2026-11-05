using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public abstract class WeaponInstance : DurableInstance, IAttack
    {
        public BaseWeapon Weapon => (BaseWeapon)Definition;

        public WeaponInstance(BaseWeapon _weapon, params IAffect<IAffectableActor>[]?effects) :
            base(_weapon,effects)
        {
            
        }

        private uint BaseAttackFunc(uint weaponDamage)
        {
            double conditionCoef = GetDurabilityCoefficient();

            uint damage = (uint)Math.Round(weaponDamage * conditionCoef);

            foreach (var effect in Effects)
            {
               
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
