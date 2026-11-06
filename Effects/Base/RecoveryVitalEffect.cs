
using System;
using CharacterMainLib;

namespace InventoryCoreLib
{
    public class RecoveryVitalEffect : BaseEffect<IAffectableCharacter, uint>
    {
        private Action<string,uint>? _targetFunc = null;

        private string vitalName = "";

        /// <summary>
        /// Use effect to recover vital parameters
        /// </summary>
        /// <param name="name">Vital parameter name from your vital system names</param>
        /// <param name="value">Power of restoration</param>
        /// <param name="duration_sec">Time effect works</param>
        public RecoveryVitalEffect(
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

        public override void SetTarget(IAffectableCharacter? target)
        {
            Target = target;

            if(Target is not null)
            {
                _targetFunc = Target.RestoreVital;
            }
            
        }
    }
}
