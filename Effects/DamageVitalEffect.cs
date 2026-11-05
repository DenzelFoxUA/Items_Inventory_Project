
using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public class DamageVitalEffect : BaseEffect<IAffectableActor,uint>
    {
        private Action<string, uint>? _targetFunc = null;

        private string vitalName = "";

        /// <summary>
        /// Use effect to damage vital parameters
        /// </summary>
        /// <param name="name">Vital parameter name from your vital system names</param>
        /// <param name="value">Damage amount</param>
        /// <param name="duration_sec">Time effect works</param>
        public DamageVitalEffect(
            string name,
            uint value)
        {
            vitalName = name;
            PowerValue = value;
        }

        public override void Apply()
        {
            if (_targetFunc is not null)
            {
                _targetFunc.Invoke(vitalName, PowerValue);
            }
        }

        public override void SetTarget(IAffectableActor? target)
        {
            Target = target;

            if(Target is not null)
            {
                _targetFunc = Target.DamageVital;
            }
        }
    }
}
