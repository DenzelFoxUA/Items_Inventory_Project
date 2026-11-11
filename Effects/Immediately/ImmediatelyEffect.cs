

using CharacterMainLib;
using System;

namespace InventoryCoreLib
{
    public abstract class ImmediatelyEffect<TTarget, TPower>
    : BaseEffect<TTarget, TPower>, IAffectImmediately<TTarget>
    where TTarget : class, IAffectable

    {

        protected Action<TPower>? _applyFunc;

        protected bool _isApplied = false;

        protected ImmediatelyEffect(TPower power)
        {
            PowerValue = power;
        }

        public abstract override void Apply();

    }
}
