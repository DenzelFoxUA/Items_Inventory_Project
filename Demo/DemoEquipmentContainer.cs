using CharacterMainLib;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class DemoEquipmentContainer : EquipmentContainer<IOwnedEquipable>
    {
        public IDemoCharacter? Owner { get; private set; } = null;

        public DemoEquipmentContainer(IAffectableCharacter? ownerRef, 
            IEnumerable<string> equipBlockNames) : base(equipBlockNames)
        {

        }

        public override bool TryEquipIntoSlot(ref IOwnedEquipable? item)
        {
            if (EquipmentSlots is null || item is null)
                return false;

            string slotCategory = item.GetEquipSlotCategory();

            bool isOk = base.TryEquipIntoSlot(ref item);

            if(isOk)
            {
                EquipmentSlots[slotCategory].ItemInstance!.Equip();
            }

            return isOk;
        }

        public override IOwnedEquipable? UnequipFromSlot(string slotName)
        {
            if (slotName == string.Empty ||
                EquipmentSlots is null ||
                !EquipmentSlots.ContainsKey(slotName)||
                EquipmentSlots[slotName] is null)
                return null;

            EquipmentSlots[slotName].ItemInstance!.Unequip();
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
                equipmentStr += $"{eq.Key} - {eq.Value.ToString()}\n";
            }

            return equipmentStr;
        }
    }
}
