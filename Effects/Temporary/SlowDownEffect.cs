using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public class SlowDownEffect : TemporaryEffect<ICanMove,float>
    {
        public SlowDownEffect(float strength, uint durationSec, string name = "Slow Effect") 
            : base(strength ,durationSec, name)
        {
        }

        public override void SetTarget(ICanMove? target)
        {

            base.SetTarget(target);

            if (Target is null)
                return;

            _applyFunc = Target.MovementSlowDown;
            _restoreFunc = Target.MovementSpeedUp;

        }

        
    }
}
