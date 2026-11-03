

using System;

namespace InventoryCoreLib
{
    public enum Elements
    {
        Fire,
        Ice,
        Shock
    }

    public class ElementalEffect : BaseEffect
    {
        
        public Elements Element { get; init; }
        private readonly IModifiableStat _target;
        //private readonly uint _value;

        public ElementalEffect(Elements element,
            IModifiableStat target,
            uint value,
            uint duration_sec)
        {
            _target = target;
            Element = element;
            PowerValue = value;
            EffectCategory = EffectCategory.Recovery;
            EffectDuration = duration_sec;
            IsPassive = false;
        }

        public override void Apply()
        {
            Console.WriteLine($"Effect {Element} applyed");
            Console.ReadLine();
            _target.Decrease(PowerValue);
        }
    }
}
