
namespace InventoryCoreLib
{
    public enum AmmoType
    {
        NotSet = 0,
        Arrow = 1,
        Bolt,
        Bullet
    }

    public interface IAmmo
    {
        public AmmoType Ammo { get; }
    }
}
