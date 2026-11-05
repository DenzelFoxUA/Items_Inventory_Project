using CharacterMainLib;
using System;

namespace InventoryCoreLib.Effects
{
    public class SlowDownEffect : TemporaryEffect<float>
    {

        public SlowDownEffect(float strength, uint durationSec) : base(strength ,durationSec)
        {
        }

        public override void SetTarget(IAffectableActor? target)
        {
            if (_isApplied)
                throw new InvalidOperationException(
                    "Cannot change target while effect is applied.");

            Target = target;

            if (Target is not null)
            {
                _applyFunc = Target.MovementSlowDown;
                _restoreFunc = Target.MovementSpeedUp;
            }

        }

        
    }
}
