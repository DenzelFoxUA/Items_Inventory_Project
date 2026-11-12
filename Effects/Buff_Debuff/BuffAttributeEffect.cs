

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

        protected bool _isRemoved = true;

        public BuffAttributeEffect(string attributeName, TPower power, string effName)
        {
            _attributeName = attributeName;
            PowerValue = power;
            Name = effName;
        }

        public override void Apply()
        {
            if (_isApplied)
                return;

            if (_applyFunc is null)
                throw new ObjectNotInitializedException(nameof(_applyFunc));

            if(_restoreFunc is null)
                throw new ObjectNotInitializedException(nameof(_restoreFunc));

            _applyFunc?.Invoke(_attributeName, PowerValue);
            _isApplied = true;
            _isRemoved = false;
        }

        public override void Remove()
        {
            if (_isRemoved)
                return;

            _restoreFunc?.Invoke(_attributeName, PowerValue);
            _isApplied = false;
            _isRemoved = true;
        }


    }
}
