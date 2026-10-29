
namespace InventoryCoreLib
{
    public interface IRanged
    {
        public void Reload();
        public void ApplyAmmunition();

        bool CanUseAmmo(IAmmo ammo);
        bool SetAmmo(IAmmo ammo);
        void ClearAmmo();
    }
}
