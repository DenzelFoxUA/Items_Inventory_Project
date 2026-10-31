
namespace InventoryCoreLib
{
    public abstract class ArmorInstance: DurableInstance
    {

        public BaseArmor Armor => (BaseArmor)Definition;

        public uint CurrentDefence { get; protected set; }

        public ArmorInstance(BaseArmor armor): base(armor)
        {

        }

    }
}
