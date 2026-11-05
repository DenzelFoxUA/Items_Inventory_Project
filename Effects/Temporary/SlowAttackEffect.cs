using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryCoreLib.Effects
{
    public class SlowAttackEffect : TemporaryEffect<float>
    {
        public SlowAttackEffect(float power, float durationSec) : base(power, durationSec)
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
                _applyFunc = Target.AttackSpeedDown;
                _restoreFunc = Target.AttackSpeedUp;
            }

        }

    }
}
