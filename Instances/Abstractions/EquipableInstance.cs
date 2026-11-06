
using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryCoreLib
{
    public abstract class EquipableInstance : UsableItemInstance, IEquipable
    {
        public EquipableItem EquipableDefinition => (EquipableItem)Definition;

        public bool IsEquipped { get; protected set; } = false;

        public EquipableInstance(BaseItem definition, params IAffect<IAffectableCharacter>[]? effects) 
            : base(definition, effects)
        {

        }

        public abstract override List<IAffect<IAffectableCharacter>>? Use();

        public abstract void Equip();

        public abstract void Unequip();

        public override string ToString()
        {
            return $"ID: {EquipableDefinition.Id}\n" +
                $"Name: {EquipableDefinition.Name}\n" +
                $"Description: {EquipableDefinition.Descriprion}\n" +
                $"Price: {EquipableDefinition.Price}\n" +
                $"Weight: {EquipableDefinition.Weight}\n" +
                $"Is Stackable: {EquipableDefinition.IsStackable}\n" +
                $"Max stack: {EquipableDefinition.MaxStackSize}\n" +
                $"Is equipped: {IsEquipped}";
        }
        
    }
}
