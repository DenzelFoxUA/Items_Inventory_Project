
using System;
using CharacterMainLib;

namespace InventoryCoreLib
{
    public class RecoveryVitalEffect : BaseEffect<IAffectableActor>
    {
        private Action<string,uint>? _targetFunc = null;

        private string vitalName = "";

        public RecoveryVitalEffect(
            string name,
            uint value,
            uint duration_sec)
        {
            vitalName = name;
            PowerValue = value;
            EffectDuration = duration_sec;
            IsPassive = false;
        }

        public override void Apply()
        {
            if(_targetFunc is not null)
            {
                _targetFunc.Invoke(vitalName, PowerValue);
            } 
        }

        public override void SetTarget(IAffectableActor? target)
        {
            Target = target;

            if(Target is not null)
            {
                _targetFunc = Target.RestoreVital;
            }
            
        }
    }
}
