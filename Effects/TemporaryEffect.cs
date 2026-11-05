using CharacterMainLib;
using System;
using System.Numerics;

namespace InventoryCoreLib
{
    public abstract class TemporaryEffect<T> : BaseEffect<IAffectableActor, T>
        where T: INumber<T>
    {

        protected Action<T>? _applyFunc = null;
        protected Action<T>? _restoreFunc = null;

        protected bool _isApplied = false;

        public bool IsExpired => EffectDuration <= 0;

        protected float EffectDuration { get; set; }

        public TemporaryEffect(T power, float durationSec)
        {
            EffectDuration = durationSec;
            PowerValue = power;
        }

        public override void Apply()
        {
            if (_isApplied)
                return;

            if (_applyFunc is null || _restoreFunc is null)
                throw new ArgumentNullException($"Functions of this effect are not set!");

            _applyFunc.Invoke(PowerValue);
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

            if (deltaTime <= 0.0f)
                return;

            if (IsExpired)
                return;

            EffectDuration -= deltaTime;

            if (IsExpired)
            {
                Remove();
            }

        }
    }
}
