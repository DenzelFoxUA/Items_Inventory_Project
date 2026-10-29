
namespace InventoryCoreLib
{
    public class ArrowInstance : EquipableInstance, IAmmoInstance
    {

        public IAmmo AmmoDefinition => (ArrowDefinition)Definition;

        public ArrowInstance(ArrowDefinition arrow) : base(arrow)
        {
            
        }

        public bool Use()
        {
            if (CurrentStackCount == 0)
                return false;

            CurrentStackCount--;
            return true;
        }
    }
}
