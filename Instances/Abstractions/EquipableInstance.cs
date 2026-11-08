
using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{
    public abstract class EquipableInstance<T> : BaseItemInstance, IEquipable
        where T : IAffect<IAffectableCharacter>
    {

        public IReadOnlyList<T> Effects { get; }

        public  IAffectableCharacter? MyOwner { get => _owner; }

        public IAffectableActor? MyTarget => _target;

        protected EquipableInstance(BaseItem definition, params T[]? effects) 
            : base(definition)
        {
            Effects = Array.AsReadOnly(effects?.ToArray() ??
                Array.Empty<T>());
        }

        private EquipableItem Item => (EquipableItem)Definition;

        public bool IsEquipped { get; protected set; } = false;

        

        public virtual object? Use()
        {
            return Effects.ToList();
        }

        public virtual void Equip()
        {
            if (IsEquipped)
                return;

            IsEquipped = true;
        }

        public virtual void Unequip()
        {
            if (!IsEquipped)
                return;

            IsEquipped = false;
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
            return Item.EqupmentCategory;
        }

        public virtual void SetItemTarget(IAffectableActor? target) { }

        public string GetDefinitionName() => Definition.Name;

        public virtual void SetMyOwner(IAffectableCharacter? owner)
        {
            if (ReferenceEquals(MyOwner, owner)) return;

            _owner = owner;
        }

        public virtual void SetMyTarget(IAffectableActor? target)
        {
            if(target is null) return;

            if (target is IAffectableCharacter _character)
            {
                _target = _character;

                foreach (var effect in Effects)
                {
                    effect.SetTarget(_character);
                }
            }


        }
    }
}
