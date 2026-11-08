using CharacterMainLib;
using System;
using System.Linq;

namespace InventoryCoreLib
{
    public abstract class WeaponInstance<T> : DurableInstance<T>, IAttack
        where T : IAffectImmediately<IAffectableCharacter>
    {
        public BaseWeapon Weapon => (BaseWeapon)Definition;

        public IAffectableActor? Target { get; protected set; } = null;

        public WeaponInstance(BaseWeapon _weapon, params T[]?effects) :
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

        public override void SetItemTarget(IAffectableActor? target)
        {
            Target = target;
        }
    }
}
