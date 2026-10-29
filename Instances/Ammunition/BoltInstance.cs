
namespace InventoryCoreLib
{
    public class BoltInstance : EquipableInstance, IAmmoInstance
    {
        public IAmmo AmmoDefinition => (BoltDefinition)Definition;

        public BoltInstance(BoltDefinition bolt): base(bolt)
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
