
using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IAttack<Effect, TTarget>
        where Effect : class, IAffectImmediately<TTarget>
        where TTarget : class, IAffectableCharacter
    {
        public AttackComplex<Effect, TTarget> PrimaryAttack(IAffectable? target);
        public AttackComplex<Effect, TTarget>? SecondaryAttack(IAffectable? target);
    }
}
