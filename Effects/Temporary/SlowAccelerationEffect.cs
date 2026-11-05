

using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public class SlowAccelerationEffect : TemporaryEffect<float>
    {

        public SlowAccelerationEffect(float power, float durationSec) 
            : base(power,durationSec)
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
                _applyFunc = Target.AccelerationDown;

                _restoreFunc = Target.AccelerationUp;
            }

        }
    }
}
