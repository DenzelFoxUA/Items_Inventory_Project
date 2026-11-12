

using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public abstract class ImmediatelyEffect<TTarget, TPower>
    : BaseEffect<TTarget, TPower>, IAffectImmediately<TTarget>
    where TTarget : class, IAffectable

    {

        protected Action<TPower>? _applyFunc;

        protected ImmediatelyEffect(TPower power, string effectName)
        {
            PowerValue = power;
            Name = effectName;
        }


        public abstract override void Apply();

    }
}
