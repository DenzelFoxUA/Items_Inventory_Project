
using CharacterMainLib;

namespace InventoryCoreLib
{
    public class ImmdRecoveryVitalEffect : ImmediatelyEffect<IAffectableActor, (string, uint)>,
        IAffectImmediately<IAffectableActor>
    {

        /// <summary>
        /// Use effect to recover vital parameters
        /// </summary>
        /// <param name="vitalName">Vital parameter name from your vital system names</param>
        /// <param name="value">Power of restoration</param>
        /// <param name="duration_sec">Time effect works</param>
        /// 
        public ImmdRecoveryVitalEffect(
            string effectName,
            string vitalName,
            uint value) : base((vitalName,value), effectName)
        {
        }

        public override void Apply()
        {
            if (_isApplied)
                return;

            if (_applyFunc is null)
                throw new ObjectNotInitializedException(nameof(_applyFunc));

            _applyFunc?.Invoke(PowerValue);
        }

        public override void SetTarget(IAffectableActor? target)
        {

            base.SetTarget(target);

            if (Target is null)
                return;

            _applyFunc = power => Target.RestoreVital(power.Item1, power.Item2);
            
        }
    }
}
