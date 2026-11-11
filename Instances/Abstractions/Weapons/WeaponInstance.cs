using CharacterMainLib;


namespace InventoryCoreLib
{
    public abstract class WeaponInstance<Effect,TTarget> : 
        DurableInstance<Effect, TTarget>, ICanDealDamage
       where Effect : class, IAffect<TTarget>
        where TTarget : class, IAffectable
    {

        public IAffectable? Target { get; protected set; } = null;

        public WeaponInstance(BaseWeapon _weapon, params Effect[]?effects) :
            base(_weapon,effects)
        {
        }

        //IAttack
        public abstract AttackComplex PrimaryAttack(IAffectable? target);

        public abstract AttackComplex? SecondaryAttack(IAffectable? target);
       

        public override void SetMyTarget(IAffectable? target)
        {
            if (ReferenceEquals(target, MyOwner))
                return;

            Target = target;
        }

    }
}
