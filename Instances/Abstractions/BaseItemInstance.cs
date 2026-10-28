
namespace InventoryCoreLib
{
    public abstract class BaseItemInstance
    {
        public BaseItem Definition { get; }

        public uint CurrentStackCount { get; protected set; } = 1;

        public BaseItemInstance(BaseItem definition)
        {
            Definition = definition;
        }
    }
}
