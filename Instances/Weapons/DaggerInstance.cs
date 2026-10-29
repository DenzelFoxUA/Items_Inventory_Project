
namespace InventoryCoreLib
{
    public class DaggerInstance : WeaponInstance
    {
        private DaggerDefinition Dagger => (DaggerDefinition)Definition;

        public DaggerInstance(DaggerDefinition daggerItem) : base(daggerItem)
        {

        }

    }
}
