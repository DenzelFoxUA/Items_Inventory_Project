
namespace InventoryCoreLib
{
    public class BulletInstance: EquipableInstance
    {
        public BulletDefinition Bullet => (BulletDefinition)Definition;

        public BulletInstance(BulletDefinition bullet) : base(bullet)
        {

        }
    }
}
