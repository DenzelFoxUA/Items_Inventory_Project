
using CharacterMainLib;

namespace InventoryCoreLib
{
    public class LeatherArmor :
        ArmorInstance<IAffectConditionally<IAffectableCharacter>,IAffectableCharacter>
    {

        public LeatherArmor(in BodyArmor armor, 
            params IAffectConditionally<IAffectableCharacter>[] effects) 
            : base(armor, effects)
        {
           
        }

        //public override void Use()
        //{
        //    SetTargetFunction();

        //    if (_useFunction is null || _unequipFunction is null)
        //        throw new NullReferenceException("Equip/Unequip funcs are not set");

        //    if (!IsEquipped)
        //        _useFunction.Invoke(this);
        //    else
        //        _unequipFunction.Invoke(this.GetEquipSlotCategory());

        //}

        //public override void Equip()
        //{
        //    if (IsEquipped)
        //        return;

        //    IsEquipped = true;

        //    foreach (var effect in Effects)
        //    {
        //        effect.SetTarget(MyOwner);
        //        effect.Apply();
        //    }

        //}

        //public override void Unequip()
        //{
        //    if (!IsEquipped)
        //        return;

        //    IsEquipped = false;

        //    foreach (var effect in Effects)
        //    {
        //        effect.Remove();
        //    }

        //    CancelMyTarget();
        //}
    }
}
