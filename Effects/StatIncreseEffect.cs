
using System;
using CharacterMainLib;

namespace InventoryCoreLib
{
    public class StatIncreseEffect : BaseEffect
    {
        private IModifiableStat? _target;

        public StatIncreseEffect(
            IModifiableStat? target,
            uint value,
            uint duration_sec)
        {
            _target = target;
            PowerValue = value;
            EffectCategory = EffectCategory.Recovery;
            EffectDuration = duration_sec;
            IsPassive = false;
        }

        public override void Apply()
        {
            Console.WriteLine($"Effect {EffectCategory} applyed");
            Console.ReadLine();

            if(_target is not null)
            {
                _target.Increase(PowerValue);
            }
            
        }

        public override void SetTarget<T>(T? target) where T : class
        {
            if(target is not null && target is IModifiableStat stat)
            {
                _target = stat;
            }
                
        }
    }
}
