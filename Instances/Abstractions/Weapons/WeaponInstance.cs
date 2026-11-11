using CharacterMainLib;


namespace InventoryCoreLib
{
    public abstract class WeaponInstance<Effect,TTarget> : 
        DurableInstance<Effect, TTarget>, IAttack<Effect, TTarget>
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
        public abstract AttackComplex<Effect,TTarget> PrimaryAttack(IAffectable? target);

        public abstract AttackComplex<Effect, TTarget>? SecondaryAttack(IAffectable? target);
       

        public override void SetMyTarget(IAffectable? target)
        {
            if (ReferenceEquals(target, MyOwner))
                return;

            Target = target;
        }

    }
}
