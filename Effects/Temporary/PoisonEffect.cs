

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

        public override void Apply()
        {
            if (IsExpired)
                return;

            if (_applyFunc is null)
                throw new InvalidOperationException("Functions of this effect are not set!");

            _applyFunc?.Invoke(PowerValue);
            _isApplied = true;
        }

        public override void SetTarget(IAffectableActor? target)
        {
            if (_isApplied)
                throw new InvalidOperationException("Cannot change target when effect is applied.");

            Target = target;

            if (Target is not null)
            {
                _applyFunc = power => Target.DamageVital(power.Item1, power.Item2);
                
            }

        }
    }
}
