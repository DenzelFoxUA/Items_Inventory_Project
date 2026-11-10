
using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{
    public abstract class EquipableInstance<TEffect, TTarget> 
        : BaseItemInstance, IOwnedEquipable
        where TTarget : class, IAffectable
        where TEffect : class, IAffect<TTarget>
    {

        private EquipableItem? Item => Definition is not null ? (EquipableItem)Definition : null;

        #region [ OWNER_TARGET ]

        protected TTarget? _target;

        public IReadOnlyList<TEffect> Effects { get; }

        public  IDemoCharacter? MyOwner { get => _owner; }

        public TTarget? MyTarget => _target;
        IAffectable? IOwnedUsable.MyTarget => MyTarget;

        #endregion

        #region [ CTOR ]

        protected EquipableInstance(BaseItem definition, params TEffect[]? effects) 
            : base(definition)
        {
            Effects = Array.AsReadOnly(effects?.ToArray() ??
                Array.Empty<TEffect>());
        }

        #endregion

        public bool IsEquipped { get; protected set; } = false;

        public abstract void Use();

        public abstract void Equip();

        public abstract void Unequip();

        public override string ToString()
        {
            if (Item is null)
                throw new NullReferenceException("Definition not set!");

            return $"ID: {Item.Id}\n" +
                $"Name: {Item.Name}\n" +
                $"Description: {Item.Descriprion}\n" +
                $"Price: {Item.Price}\n" +
                $"Weight: {Item.Weight}\n" +
                $"Is Stackable: {Item.IsStackable}\n" +
                $"Max stack: {Item.MaxStackSize}\n" +
                $"Is equipped: {IsEquipped}";
        }

        public string GetEquipSlotCategory()
        {
            if (Item is null)
                throw new NullReferenceException("Definition not set!");

            return Item.EqupmentCategory;
        }

        public string GetDefinitionName()
        {
            if (Item is null)
                throw new NullReferenceException("Definition not set!");

            return Item.Name;
        }

        public IReadOnlyList<IAffect>? GetEffects()
        {
            return Effects;
        }

        #region [ OWNER_TARGET_SET ]

        public virtual void SetMyOwner(IDemoCharacter? owner)
        {
            if (ReferenceEquals(MyOwner, owner)) return;

            _owner = owner;
        }

        public virtual void SetMyTarget(IAffectable? target)
        {
            if(target is null) return;

            if (target is TTarget _character)
            {
                _target = _character;

                foreach (var effect in Effects)
                {
                    effect.SetTarget(_character);
                }
            }
        }

        public virtual void CancelMyTarget()
        {
            _target = null;

            foreach (var effect in Effects)
            {
                effect.SetTarget(null);
            }
        }

        #endregion

        #region [ EQUALS ]

        public bool Equals(EquipableInstance<TEffect, TTarget>? other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (other is not EquipableInstance<TEffect, TTarget> otherItem)
                return false;

            return Equals(this.Definition, otherItem.Definition) &&
                Effects.SequenceEqual(otherItem.Effects);
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as EquipableInstance<TEffect, TTarget>);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();

            hash.Add(base.GetHashCode());

            hash.Add(Effects.Count);

            foreach (var effect in Effects)
                hash.Add(effect);

            return hash.ToHashCode();
        }


        #endregion

        EquipableItem? IOwnedEquipable.GetDefinition()
        {
            return Item;
        }
    }
}
