
namespace InventoryCoreLib
{
    public class DaggerInstance : WeaponInstance
    {
        public DaggerDefinition Dagger => (DaggerDefinition)Definition;

        public DaggerInstance(DaggerDefinition daggerItem) : base(daggerItem)
        {

        }

    }
}
