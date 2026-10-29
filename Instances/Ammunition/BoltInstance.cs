
namespace InventoryCoreLib
{
    public class BoltInstance : EquipableInstance, IAmmoInstance
    {
        public IAmmo AmmoDefinition => (BoltDefinition)Definition;

        public BoltInstance(BoltDefinition bolt): base(bolt)
        {

        }

        public void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}
