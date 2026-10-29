
namespace InventoryCoreLib
{
    public abstract class RangedInstance : WeaponInstance, IRanged
    {

        private RangedWeapon RangedWeapon => (RangedWeapon)Definition;

        public IAmmoInstance? CurrentAmmoInstance { get; protected set; }

        public uint CurrentAmmoCount { get; protected set; } = 0;

        public RangedInstance(RangedWeapon _weapon) :
            base(_weapon)
        {

        }

        public abstract bool Reload();

        public abstract bool CanUseAmmo(IAmmoInstance ammo);

        public abstract bool SetAmmo(IAmmoInstance ammo);

        public virtual void ClearAmmo()
        {
            CurrentAmmoCount = 0;
            CurrentAmmoInstance = null;
        }
    }
}
