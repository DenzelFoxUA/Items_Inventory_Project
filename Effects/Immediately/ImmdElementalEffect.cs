
using CharacterMainLib;

namespace InventoryCoreLib
{

    public abstract class ImmdElementalEffect : ImmediatelyEffect<IAffectableActor, (string,uint)>
    {
        
        public Elements Element { get; protected init; }

        public ImmdElementalEffect(string effName, Elements element, uint value) 
            : base(("Health",value), effName)
        {
            Element = element;
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

            _applyFunc = value => Target.DamageVital(value.Item1,value.Item2);
        }

    }
}
