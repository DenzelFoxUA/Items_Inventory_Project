using CharacterMainLib;

namespace InventoryCoreLib
{
    public class StrengthBuffEffect : BuffAttributeEffect<IAffectableCharacter, uint>,
        IAffectConditionally<IAffectableCharacter>
    {
        public StrengthBuffEffect(uint power) : base("Strength", power)
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
