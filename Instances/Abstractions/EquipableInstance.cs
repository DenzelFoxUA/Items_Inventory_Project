
namespace InventoryCoreLib
{
    public abstract class EquipableInstance : BaseItemInstance, IEquipable
    {
        private EquipableItem EquipableDefinition => (EquipableItem)Definition;

        public bool IsEquipped { get; protected set; } = false;

        public EquipableInstance(EquipableItem definition) 
            : base(definition)
        {
        }

        public virtual void Equip()
        {
            IsEquipped = true;
        }
        
        public virtual void Unequip()
        {
            IsEquipped = false;
        }

        public override string ToString()
        {
            return $"ID: {EquipableDefinition.Id}\n" +
                $"Name: {EquipableDefinition.Name}\n" +
                $"Description: {EquipableDefinition.Descriprion}\n" +
                $"Price: {EquipableDefinition.Price}\n" +
                $"Weight: {EquipableDefinition.Weight}\n" +
                $"Is Stackable{EquipableDefinition.IsStackable}\n" +
                $"Max stack{EquipableDefinition.MaxStackSize}\n" +
                $"Is equipped: {IsEquipped}";
        }
        
    }
}
