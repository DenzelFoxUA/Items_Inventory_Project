

namespace InventoryCoreLib
{
    public abstract class BaseEffect : IEffect
    {
        public uint Id { get; init; }

        public string Name { get; init; } = "";

        public string Describtion { get; init; } = "";

        public bool IsDestructive { get; init; }

        public uint Apply()
        {
            throw new System.NotImplementedException();
        }
    }
}
