
using CharacterMainLib;

namespace InventoryCoreLib
{
    public abstract class RangedInstance<T> : WeaponInstance<T>, IRanged
        where T : IAffectImmediately<IAffectableCharacter>
    {

        public RangedWeapon RangedWeapon => (RangedWeapon)Definition;

        public IAmmoInstance? CurrentAmmoInstance { get; protected set; }

        public uint CurrentAmmoCount { get; protected set; } = 0;

        public RangedInstance(RangedWeapon _weapon,
            params IAffectImmediately<IAffectableCharacter>[]? effects) :
            base(_weapon)
        {

        }

        public abstract bool Reload();

        public abstract bool CanUseAmmo(IAmmoInstance ammo);

        public abstract bool SetAmmo(IAmmoInstance ammo);

        public virtual void ClearAmmo()
        {

        }
    }
}
