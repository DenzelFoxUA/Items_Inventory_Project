

using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public class PoisonEffect : TemporaryEffect<IAffectableActor, (string, uint)>
    {
        public PoisonEffect(uint power, float durationSec) 
            : base(("Health",power), durationSec)
        {
        }

        public override void SetTarget(IAffectableActor? target)
        {
            if (_isApplied)
                throw new InvalidOperationException("Cannot change target when effect is applied.");

            Target = target;

            _applyFunc = null;
            _restoreFunc = null;

            if (Target is not null)
            {
                _applyFunc = power => Target.DamageVital(power.Item1, power.Item2);
            }

        }
    }
}
