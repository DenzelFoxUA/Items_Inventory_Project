
namespace InventoryCoreLib
{
    public interface IRanged
    {
        public bool Reload();
        public bool CanUseAmmo(IAmmoInstance ammo);
        public bool SetAmmo(IAmmoInstance ammo);
        public void ClearAmmo();
    }
}
