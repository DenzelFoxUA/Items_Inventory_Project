
namespace InventoryCoreLib
{
    public class BulletInstance : EquipableInstance, IAmmoInstance
    {
        public IAmmo AmmoDefinition => (BulletDefinition)Definition;

        public BulletInstance(BulletDefinition bullet) : base(bullet)
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
