
namespace InventoryCoreLib
{
    public abstract class EquipableInstance : BaseItemInstance
    {
        public EquipableItem EquipableDefinition => (EquipableItem)Definition;

        public bool IsEquipped { get; protected set; } = false;

        public EquipableInstance(EquipableItem definition) : base(definition)
        {

        }
    }
}
