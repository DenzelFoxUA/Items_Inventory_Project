
using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{
    public abstract class UsableItemInstance<TEffect, TTarget> : BaseItemInstance, IStackable
        where TTarget: IAffectable
        where TEffect : class, IAffect<TTarget>
    {
        private UsableItem? Item => Definition is not null ? (UsableItem)Definition : null;

        private uint _currStackCount = 1;

        public uint CurrentStackCount { get => _currStackCount; }

        public IReadOnlyList<TEffect> Effects { get; }

        IReadOnlyList<IAffect>? IOwnedUsable.GetEffects() => Effects;

        // ===================================================

        #region [ Owner - Target ]

        protected TTarget? _target;

        public IDemoCharacter? MyOwner => (IDemoCharacter)_owner!;

        public TTarget? MyTarget => _target;

        IAffectable? IOwnedUsable.MyTarget => MyTarget;

        #endregion

        //====================================================

        #region [ CTOR ]

        public UsableItemInstance(
            BaseItem item, 
            uint stackCount, 
            params TEffect[]? effects) 
            : base(item)
        {
            _currStackCount = stackCount;
            
            Effects = Array.AsReadOnly(effects?.ToArray() ??
                Array.Empty<TEffect>());
        }

        #endregion

        public abstract void Use();

        #region [ STACK OPERATIONS ]

        public virtual uint AddToStack(uint count)
        {
            if (Definition is null)
                throw new NullReferenceException("Definition of item not set");

            if (!Definition.IsStackable)
                return count;

            if (CurrentStackCount >= Definition.MaxStackSize)
            {
                return count;
            }
            else if (count >= Definition.MaxStackSize - CurrentStackCount)
            {
                uint difference = Definition.MaxStackSize - CurrentStackCount;
                _currStackCount = Definition.MaxStackSize;
                return count - difference;
            }
            else
            {
                _currStackCount += count;
                return 0;
            }
        }

        public virtual uint RemoveFromStack(uint count)
        {
            if (Definition is null)
                throw new NullReferenceException("Definition of item not set");

            if (!Definition.IsStackable)
                return 0;

            uint toRemove = Math.Min(count, CurrentStackCount);

            _currStackCount -= toRemove;

            return count - toRemove;
        }

        #endregion

        public override string ToString()
        {
            if (Definition is null)
                throw new NullReferenceException("Definition of item not set");

            string itemEff = "";

            if (Effects is null)
                itemEff = "no effect";
            else
            {
                foreach (var effect in Effects)

                    itemEff += effect.ToString() + "\n";
            }

            return Definition.ToString() + "\n" + itemEff;
        }


        public string GetDefinitionName() => Item!.Name;

        #region [ OWNER_TARGET_SET ]

        public virtual void SetMyOwner(IDemoCharacter? owner)
        {
            if (owner is null || ReferenceEquals(MyOwner, owner)) return;

            _owner = owner;
        }

        public virtual void SetMyTarget(IAffectable? target)
        {
            if (target is null) return;

            if (target is not TTarget tTarget)
                return;

            _target = tTarget;

            foreach (var effect in Effects)
            {
                effect.SetTarget(_target);
            }

        }

        #endregion

        #region [ EQUALS ]

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(base.GetHashCode());

            hash.Add(Effects.Count);

            foreach (var effect in Effects)
                hash.Add(effect);

            return hash.ToHashCode();
        }

        public bool Equals(UsableItemInstance<TEffect, TTarget>? other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (other is not UsableItemInstance<TEffect, TTarget> otherItem)
                return false;

            return Equals(this.Definition, otherItem.Definition) &&
                Effects.SequenceEqual(otherItem.Effects);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as UsableItemInstance<TEffect, TTarget>);
        }

        #endregion

    }
}
