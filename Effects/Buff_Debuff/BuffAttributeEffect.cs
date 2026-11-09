

using CharacterMainLib;
using System;
using System.Numerics;

namespace InventoryCoreLib
{
    public abstract class BuffAttributeEffect<TTarget, TPower>
        : BaseEffect<TTarget, TPower>, IAffectImmediately<TTarget>
            where TTarget : class, IAffectable
            where TPower : INumber<TPower>
    {
        private string _attributeName;

        protected Action<string, TPower>? _applyFunc;
        protected Action<string, TPower>? _restoreFunc;

        protected bool _isApplied = false;

        public BuffAttributeEffect(string name, TPower power)
        {
            _attributeName = name;
            PowerValue = power;
        }

        public override void Apply()
        {
            if (_isApplied)
                return;

            if (_applyFunc is null || _restoreFunc is null)
                throw new InvalidOperationException("Functions of this effect are not set!");

            _applyFunc(_attributeName, PowerValue);
            _isApplied = true;
        }

        public override void Remove()
        {
            if (!_isApplied)
                return;

            _restoreFunc?.Invoke(_attributeName, PowerValue);
            _isApplied = false;
        }

        public abstract override void SetTarget(TTarget? target);

    }
}
