
namespace InventoryCoreLib
{
    public interface IRanged
    {
        public bool Reload();
        bool CanUseAmmo(IAmmoInstance ammo);
        bool SetAmmo(IAmmoInstance ammo);
        void ClearAmmo();
    }
}
