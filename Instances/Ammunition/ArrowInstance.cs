
namespace InventoryCoreLib
{
    public class ArrowInstance : EquipableInstance
    {
        private ArrowDefinition Arrow => (ArrowDefinition)Definition;

        public ArrowInstance(ArrowDefinition arrow) : base(arrow)
        {
            
        }

    }
}
