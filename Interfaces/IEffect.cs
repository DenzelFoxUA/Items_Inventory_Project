
namespace InventoryCoreLib
{
    public enum Force
    {
        NotSet = 0,
        Fire = 1,
        Ice,
        Shock,
        Curse
    }

    public struct ForceEffect
    {
        public Force ApplyableForce { get; init; }
        public uint Power { get; init; }
    }

    public interface IEffect
    {
        public bool IsPassive { get; init; }
        public ForceEffect Apply();
    }
}
