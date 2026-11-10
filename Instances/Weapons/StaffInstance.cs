

using CharacterMainLib;

namespace InventoryCoreLib
{
    public class StaffInstance :
        WeaponInstance<IAffectImmediately<IAffectableCharacter>, IAffectableCharacter>
    {
        public StaffInstance(BaseWeapon _weapon, 
            params IAffectImmediately<IAffectableCharacter>[]? effects) 
            : base(_weapon, effects)
        {
        }

        public override void Equip()
        {
            if (IsEquipped)
                return;

            IsEquipped = true;
        }

        public override void SetTargetFunction()
        {
            
        }

        public override void Unequip()
        {
            if (!IsEquipped)
                return;

            IsEquipped = false;

            CancelMyTarget();
        }

        public override void Use()
        {
            throw new System.NotImplementedException();
        }
    }
}
