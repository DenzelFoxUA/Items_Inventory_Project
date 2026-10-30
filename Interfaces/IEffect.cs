
namespace InventoryCoreLib
{
    public interface IEffect
    {
        public bool IsDestructive { get; init; }
        public uint Apply();
    }
}
