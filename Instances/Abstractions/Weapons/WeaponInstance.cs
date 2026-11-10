using CharacterMainLib;


namespace InventoryCoreLib
{
    public abstract class WeaponInstance<Effect,TTarget> : DurableInstance<Effect, TTarget>, IAttack
       where Effect : class, IAffectImmediately<TTarget>
        where TTarget : class, IAffectableCharacter
    {
        private BaseWeapon Weapon => (BaseWeapon)Definition;

        public IAffectable? Target { get; protected set; } = null;

        public WeaponInstance(BaseWeapon _weapon, params Effect[]?effects) :
            base(_weapon,effects)
        {
        }

        //IAttack
        public virtual void PrimaryAttack(ref IAffectable? target, double distanceToTarget) { }
        //{
        //    if (Weapon.PrimaryAttack == null)
        //        throw new ArgumentNullException("ERR::Primary attack not set!");

        //    if (distanceToTarget <= Weapon.PrimaryAttack.AttackRange)
        //    {
        //        return BaseAttackFunc(Weapon.PrimaryAttack.MaxDamage);
        //    }

        //    return 0;
        //}

        public virtual void SecondaryAttack(ref IAffectable? target, double distanceToTarget) { }
        //{
        //    if (Weapon.SecondaryAttack is null)
        //        return null;

        //    if (distanceToTarget <= Weapon.SecondaryAttack.AttackRange)
        //    {
        //        return BaseAttackFunc(Weapon.SecondaryAttack.MaxDamage);
        //    }

        //    return 0;

        //}

        public override void SetMyTarget(IAffectable? target)
        {
            if (ReferenceEquals(target, MyOwner))
                return;

            Target = target;
        }

    }
}
