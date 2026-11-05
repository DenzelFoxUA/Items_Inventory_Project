
namespace InventoryCoreLib
{
    public class DaggerInstance : WeaponInstance
    {
        public DaggerDefinition Dagger => (DaggerDefinition)Definition;

        public DaggerInstance(DaggerDefinition daggerItem) : base(daggerItem)
        {

        }

        public override void SetItemTarget<T>(T? target) where T : default
        {
            throw new System.NotImplementedException();
        }

        public override object? Use()
        {
            throw new System.NotImplementedException();
        }

        public override uint AddToStack(uint count)
        {
            throw new System.NotImplementedException();
        }

        public override uint RemoveFromStack(uint count)
        {
            throw new System.NotImplementedException();
        }
    }
}
