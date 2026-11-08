using CharacterMainLib;

namespace InventoryCoreLib.Effects.Static
{
    public class StaticStrengthUpEffect : StaticIncreaseAttributeEffect<IAffectableCharacter, uint>,
        IAffectConditionally<IAffectableCharacter>
    {
        public StaticStrengthUpEffect(uint power) : base("Strength", power)
        {

        }

        public override void SetTarget(IAffectableCharacter? target)
        {
            Target = target;

            if (Target is not null)
            {
                _applyFunc = Target.IncreaseAttribute;
                _restoreFunc = Target.DecreaseAttribute;
            }
        }
    }
}
