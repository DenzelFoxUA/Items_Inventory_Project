using CharacterMainLib;

namespace InventoryCoreLib
{
    internal class IntelligenceBuffEffect:
        BuffAttributeEffect<IAffectableCharacter, uint>,
        IAffectConditionally<IAffectableCharacter>
    {
        public IntelligenceBuffEffect(uint power, string effName = "Intelligence boos") 
            : base("Intelligence", power, effName)
        {

        }

        public override void SetTarget(IAffectableCharacter? target)
        {

            base.SetTarget(target);

            if (Target is null)
                return;

            _applyFunc = Target!.IncreaseAttribute;
            _restoreFunc = Target.DecreaseAttribute;
        }
    }
}
