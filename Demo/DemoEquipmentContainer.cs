using CharacterMainLib;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.VisualBasic;

namespace InventoryCoreLib
{
    public class DemoEquipmentContainer : EquipmentContainer<IOwnedEquipable>
    {
        public IDemoCharacter? Owner { get; private set; } = null;

        public DemoEquipmentContainer(IAffectableCharacter? ownerRef, 
            IEnumerable<string> equipBlockNames) : base(equipBlockNames)
        {

        }

        private bool TryEquipWeapon(ref IOwnedEquipable? weapon)
        {

            if (weapon is null)
                throw new InvalidOperationException("Weapon is null");

            if (EquipmentSlots is null)
                throw new NullReferenceException("Equipment is null");

            bool isOk = false;

            if (weapon.GetDefinition() is BaseWeapon definition)
            {
                if (definition.IsTwoHanded)
                {

                    if (EquipmentSlots["Shield"].IsAvailable && EquipmentSlots["Weapon"].IsAvailable)
                    {
                        isOk = base.TryEquipIntoSlot(ref weapon);

                        if (isOk)
                        {
                            EquipmentSlots["Weapon"].ItemInstance!.Equip();
                            EquipmentSlots["Shield"].SetAvailability(false);
                        }
                    }

                    return isOk;
                }
                else if (!definition.IsTwoHanded && EquipmentSlots["Weapon"].IsAvailable)
                {
                    isOk = base.TryEquipIntoSlot(ref weapon);

                    if (isOk)
                    {
                        EquipmentSlots["Weapon"].ItemInstance!.Equip();
                    }

                    return isOk;
                }
                else
                    return isOk;
            }

            return isOk;

        }

        private bool TryEquipShield(ref IOwnedEquipable? shield)
        {
            if (shield is null)
                throw new InvalidOperationException("Shield is null");

            if (EquipmentSlots is null)
                throw new NullReferenceException("Equipment is null");

            bool isOk = false;

            if (EquipmentSlots["Weapon"].ItemInstance is not null)
            {
                var definition = EquipmentSlots["Weapon"].ItemInstance!.GetDefinition() 
                    as BaseWeapon;

                if(definition!.IsTwoHanded)
                {
                    return isOk;
                }
            }

            isOk = base.TryEquipIntoSlot(ref shield);

            if (isOk)
            {
                EquipmentSlots["Shield"].ItemInstance!.Equip();
            }

            return isOk;
        }

        public override bool TryEquipIntoSlot(ref IOwnedEquipable? item)
        {
            if (EquipmentSlots is null || item is null)
                return false;

            string slotCategory = item.GetEquipSlotCategory();

            if(slotCategory == "Weapon")
            {
                return TryEquipWeapon(ref item);
            }
            else if(slotCategory == "Shield")
            {
                return TryEquipShield(ref item);
            }
            else
            {
                bool isOk = base.TryEquipIntoSlot(ref item);

                if (isOk)
                {
                    EquipmentSlots[slotCategory].ItemInstance!.Equip();
                }

                return isOk;
            }
            
        }

        public override IOwnedEquipable? UnequipFromSlot(string slotName)
        {
            if (slotName == string.Empty ||
                EquipmentSlots is null ||
                !EquipmentSlots.ContainsKey(slotName)||
                EquipmentSlots[slotName] is null)
                return null;

            //EquipmentSlots[slotName].ItemInstance!.Unequip();
            return EquipmentSlots[slotName].Unequip();
        }

        public override string ItemInfo(string slotName)
        {
            if(EquipmentSlots is not null && 
                EquipmentSlots[slotName].ItemInstance is { } item)
            {
                item.ToString();
            }

            return string.Empty;
        }

        public override void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public override string ShowEquipment()
        {
            string equipmentStr = "";

            if (EquipmentSlots is null)
                return "NOTHING TO SHOW";

            foreach(var eq in EquipmentSlots)
            {
                string itemName = "EMPTY SLOT";

                if (eq.Value.ItemInstance is not null)
                    itemName = eq.Value.ItemInstance.GetDefinitionName();

                equipmentStr += $"{eq.Key} - [ {itemName} ]\n";
            }

            return equipmentStr;
        }

        public AttackComplex? UseWeaponPrimary(IAffectable? currTarget)
        {
            if (EquipmentSlots is null || EquipmentSlots["Weapon"] is null)
            {
                return null;
            }

            if (EquipmentSlots["Weapon"].ItemInstance is 
                ICanDealDamage weapon)
            {
                weapon.SetMyTarget(currTarget);
                return weapon.PrimaryAttack(weapon.MyTarget);
            }

            return null;
        }

        public AttackComplex? UseWeaponSecondary(IAffectable? currTarget)
        {
            if (EquipmentSlots is null || EquipmentSlots["Weapon"] is null)
            {
                return null;
            }

            if (EquipmentSlots["Weapon"].ItemInstance is
                WeaponInstance<IAffectImmediately<IAffectableCharacter>, IAffectableCharacter> weapon)
            {

                weapon.SetMyTarget(currTarget);
                return weapon.SecondaryAttack(weapon.MyTarget);
            }

            return null;
        }
    }
}
