using CharacterMainLib;
using System;
using System.Collections.Generic;


namespace InventoryCoreLib
{
    public abstract class WeaponInstance<Effect,TTarget> : 
        DurableInstance<Effect, TTarget>, ICanDealDamage
       where Effect : class, IAffect<TTarget>
        where TTarget : class, IAffectable
    {

        public BaseWeapon Weapon
        {
            get
            {
                if (Definition is null)
                    throw new ObjectNotInitializedException(nameof(Definition));

                return (BaseWeapon)Definition;
            }
        }

        public IAffectable? Target { get; protected set; } = null;

        public uint CurrentPrimaryDamage { get; protected set; } = 0;
        public uint CurrentSecondaryDamage { get; protected set; } = 0;

        public WeaponInstance(BaseWeapon _weapon, params Effect[]?effects) :
            base(_weapon,effects)
        {
            CurrentPrimaryDamage = Weapon.PrimaryAttack.MaxDamage;

            if(Weapon.SecondaryAttack is not null)
            {
                CurrentPrimaryDamage = Weapon.SecondaryAttack.MaxDamage;
            }
        }

        //IAttack
        public AttackComplex PrimaryAttack(IAffectable? target)
        {
            if (Weapon.PrimaryAttack == null)
                throw new ObjectNotInitializedException(nameof(Weapon.PrimaryAttack));

            var dist = Weapon.PrimaryAttack.AttackRange;

            return new AttackComplex(CurrentPrimaryDamage, dist, Effects);
        }

        public AttackComplex? SecondaryAttack(IAffectable? target)
        {
            if (Weapon.SecondaryAttack is null)
            {
                return null;
            }

            var dist = Weapon.PrimaryAttack.AttackRange;

            return new AttackComplex(CurrentSecondaryDamage, dist, Effects);
        }


        public override void SetMyTarget(IAffectable? target)
        {
            if (ReferenceEquals(target, MyOwner))
                return;

            Target = target;
        }

        private uint UpdateDamage(double source)
        {
            var coef = GetDurabilityCoefficient();

            source *= coef;

            return (uint)Math.Round(source);
        }

        public override void Update()
        {
            CurrentPrimaryDamage = UpdateDamage(Weapon.PrimaryAttack.MaxDamage);

            if (Weapon.SecondaryAttack is not null)
            {
                CurrentSecondaryDamage = UpdateDamage(Weapon.SecondaryAttack.MaxDamage);
            }
        }
    }
}
