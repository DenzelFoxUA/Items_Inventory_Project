
namespace InventoryCoreLib
{
    public class BoltInstance : EquipableInstance
    {
        private BoltDefinition Bolt => (BoltDefinition)Definition;

        public BoltInstance(BoltDefinition bolt): base(bolt)
        {

        }
    }
}
