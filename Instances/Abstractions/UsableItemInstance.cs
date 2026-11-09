
using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{
    public abstract class UsableItemInstance<T> : BaseItemInstance, IStackable
        where T : IAffectImmediately<IAffectableActor>
    {
        private UsableItem Item => (UsableItem)Definition;

        private uint _currStackCount = 1;

        public uint CurrentStackCount { get => _currStackCount; }

        public IReadOnlyList<T> Effects { get; }

        #region [ Owner - Target ]

        public IDemoCharacter? MyOwner => (IDemoCharacter)_owner;

        public IAffectableActor? MyTarget => _target;

        #endregion

        public UsableItemInstance(
            BaseItem item, 
            uint stackCount, 
            params T[]? effects) 
            : base(item)
        {
            _currStackCount = stackCount;
            
            Effects = Array.AsReadOnly(effects?.ToArray() ??
                Array.Empty<T>());
        }

        public abstract void Use();

        public virtual uint AddToStack(uint count)
        {
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
            if (!Definition.IsStackable)
                return 0;

            uint toRemove = Math.Min(count, CurrentStackCount);

            _currStackCount -= toRemove;

            return count - toRemove;
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(base.GetHashCode());

            if (Effects is null)
            {
                hash.Add(-1);
            }
            else
            {
                hash.Add(Effects.Count);

                foreach (var effect in Effects)
                    hash.Add(effect);
            }

            return hash.ToHashCode();
        }

        public override string ToString()
        {
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


        public string GetDefinitionName()
        {
            return Item.Name;
        }

        public virtual void SetMyOwner(IDemoCharacter? owner)
        {
            if (owner is null || ReferenceEquals(MyOwner, owner)) return;

            _owner = owner;
        }

        public virtual void SetMyTarget(IAffectableActor? target)
        {
            if (target is null) return;

            if (Item.IsSelfApplycable)
                _target = _owner;
            else
                _target = target;

            foreach (var effect in Effects)
            {
                effect.SetTarget(_target);
            }

        }

        public object? GetEffects()
        {
            return Effects.ToList().AsReadOnly();
        }
    }
}
