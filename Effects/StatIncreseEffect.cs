
using System;

namespace InventoryCoreLib
{
    public class StatIncreseEffect : BaseEffect
    {
        private readonly IModifiableStat _target;
        //private readonly uint _value;

        public StatIncreseEffect(
            IModifiableStat target,
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
            _target.Increase(PowerValue);
        }
    }
}
