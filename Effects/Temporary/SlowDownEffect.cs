using CharacterMainLib;
using System;

namespace InventoryCoreLib.Effects
{
    public class SlowDownEffect : TemporaryEffect<ICanMove,float>
    {
        public SlowDownEffect(float strength, uint durationSec) : base(strength ,durationSec)
        {
        }

        public override void SetTarget(ICanMove? target)
        {
            if (_isApplied)
                throw new InvalidOperationException("Cannot change target when effect is applied.");

            Target = target;

            if (Target is not null)
            {
                _applyFunc = Target.MovementSlowDown;
                _restoreFunc = Target.MovementSpeedUp;
            }

        }

        
    }
}
