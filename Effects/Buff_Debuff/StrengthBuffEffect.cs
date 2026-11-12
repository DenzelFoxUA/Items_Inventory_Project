using CharacterMainLib;

namespace InventoryCoreLib
{
    public class StrengthBuffEffect : BuffAttributeEffect<IAffectableCharacter, uint>,
        IAffectConditionally<IAffectableCharacter>
    {
        public StrengthBuffEffect(uint power, string effName = "Strength boost") 
            : base("Strength", power, effName)
        {

        }

        public override void SetTarget(IAffectableCharacter? target)
        {
            base.SetTarget(target);

            if (Target is null)
                return;

            _applyFunc = Target.IncreaseAttribute;
            _restoreFunc = Target.DecreaseAttribute;
           
        }
    }
}
