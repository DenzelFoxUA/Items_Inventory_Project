
using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public class ImmdDamageVitalEffect : ImmediatelyEffect<IAffectableActor, (string,uint)>
    {

        /// <summary>
        /// Use effect to damage vital parameters
        /// </summary>
        /// <param name="vitalName">Vital parameter name from your vital system names</param>
        /// <param name="value">Damage amount</param>
        /// 
        public ImmdDamageVitalEffect(
            string effectName,
            string vitalName,
            uint value) : base((vitalName, value), effectName)
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

            _applyFunc = power => Target.DamageVital(power.Item1, power.Item2);
        }
    }
}
