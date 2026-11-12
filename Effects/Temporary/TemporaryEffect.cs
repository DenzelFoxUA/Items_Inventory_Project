using CharacterMainLib;
using System;
using System.Numerics;

namespace InventoryCoreLib
{
    public abstract class TemporaryEffect<TTarget, TPower>
    : BaseEffect<TTarget, TPower>, IAffectTemporary<TTarget>
    where TTarget : class, IAffectable
    
    {
        protected Action<TPower>? _applyFunc;
        protected Action<TPower>? _restoreFunc;

        public bool IsExpired => EffectDuration <= 0;

        protected float EffectDuration { get; set; }

        protected TemporaryEffect(TPower power, float durationSec, string effectName)
        {
            if (durationSec <= 0.0f)
                throw new ArgumentOutOfRangeException(nameof(durationSec));

            EffectDuration = durationSec;
            PowerValue = power;
            Name = effectName;
        }

        public override void Apply()
        {
            if (IsExpired)
                return;

            if (_applyFunc is null || _restoreFunc is null)
                throw new InvalidOperationException("Functions of this effect are not set!");

            _applyFunc?.Invoke(PowerValue);
            _isApplied = true;
        }

        public override void Remove()
        {
            if (!_isApplied)
                return;

            _restoreFunc?.Invoke(PowerValue);
            _isApplied = false;
        }

        public virtual void Update(float deltaTime)
        {
            if (deltaTime <= 0.0f || IsExpired)
                return;

            Apply();

            EffectDuration -= deltaTime;

            if (IsExpired)
                Remove();
        }

        public bool IsEffectExpired() => IsExpired;
    }
}
