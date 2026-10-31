
namespace InventoryCoreLib
{
    public enum ApplyableEffect
    {
        NotSet = 0,
        Fire = 1,
        Ice,
        Shock,
        Curse,
        Poison,
        Heal,
        RestoreMana,
        RestoreStamina,
        DamageHealth,
        DamageMana,
        DamageStamina,
        IncreaseStats,
        DecreaseStats,
        RechargeItem,
        Unlock,
        Repair
    }

    public struct ForceEffect
    {
        public ApplyableEffect ApplyableForce { get; init; }
        public uint Duration { get; init; }
        public uint Power { get; init; }
    }

    public interface IEffect
    {
        public bool IsPassive { get; }
        public ForceEffect Apply();
    }
}
