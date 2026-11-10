using CharacterMainLib;

namespace InventoryCoreLib
{
    internal class IntelligenceBuffEffect:
        BuffAttributeEffect<IAffectableCharacter, uint>,
        IAffectConditionally<IAffectableCharacter>
    {
        public IntelligenceBuffEffect(uint power) : base("Intelligence", power)
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
