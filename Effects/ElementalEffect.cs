
using System;
using CharacterMainLib;

namespace InventoryCoreLib
{
    public enum Elements
    {
        Fire,
        Ice,
        Shock
    }

    public class ElementalEffect : BaseEffect<IAffectable, uint>
    {

        public Elements Element { get; init; }
        private readonly IModifiableStat _target;
        //private readonly uint _value;

        public ElementalEffect(Elements element,
            IModifiableStat target,
            uint value)
        {
            _target = target;
            Element = element;
            PowerValue = value;
        }

        public override void Apply()
        {
            Console.WriteLine($"Effect {Element} applyed");
            Console.ReadLine();
            _target.Decrease(PowerValue);
        }

        public override void SetTarget(IAffectable? target)
        {
            throw new NotImplementedException();
        }
    }
}
