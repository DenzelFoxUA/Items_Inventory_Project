
namespace InventoryCoreLib
{
    public interface IRanged
    {
        public void Reload();
        bool CanUseAmmo(IAmmo ammo);
        bool SetAmmo(IAmmo ammo);
        void ClearAmmo();
    }
}
