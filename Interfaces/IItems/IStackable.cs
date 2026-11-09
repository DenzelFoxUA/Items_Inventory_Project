using CharacterMainLib;

namespace InventoryCoreLib
{
    public interface IStackable : IOwnedUsable
    {
        public uint CurrentStackCount { get; }

        public uint AddToStack(uint count);

        public uint RemoveFromStack(uint count);

    }
}
