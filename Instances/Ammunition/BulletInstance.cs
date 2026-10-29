
namespace InventoryCoreLib
{
    public class BulletInstance: EquipableInstance, IAmmoInstance
    {
        public IAmmo AmmoDefinition => (BulletDefinition)Definition;

        public BulletInstance(BulletDefinition bullet) : base(bullet)
        {

        }
    }
}
