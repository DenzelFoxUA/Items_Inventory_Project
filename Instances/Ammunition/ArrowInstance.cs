
namespace InventoryCoreLib
{
    public class ArrowInstance : EquipableInstance, IAmmoInstance
    {

        public IAmmo AmmoDefinition => (ArrowDefinition)Definition;

        public ArrowInstance(ArrowDefinition arrow) : base(arrow)
        {
            
        }

        public void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}
