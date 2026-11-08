

using CharacterMainLib;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

namespace InventoryCoreLib
{
    public class DemoEquipmentContainer : EquipmentContainer<IEquipable>
    {
        public DemoEquipmentContainer(IAffectableCharacter? ownerRef, 
            IEnumerable<string> equipBlockNames) : base(ownerRef, equipBlockNames)
        {
        }


        public override bool TryEquipIntoSlot(ref IEquipable? item)
        {
            if (EquipmentSlots is null || item is null)
                return false;

            string slotCategory = item.GetEquipSlotCategory();

            bool isOk = base.TryEquipIntoSlot(ref item);

            if(isOk)
            {
                if(EquipmentSlots[slotCategory].ItemInstance!.Use() 
                    is List<IAffectConditionally<IAffectableCharacter>> effectList)
                {
                    foreach (var effect in effectList)
                    {
                        effect.SetTarget(Owner);
                        effect.Apply();
                    }
                }

            }

            return isOk;
        }

        public override IEquipable? UnequipFromSlot(string slotName)
        {
            if (slotName == string.Empty ||
                EquipmentSlots is null ||
                !EquipmentSlots.ContainsKey(slotName)||
                EquipmentSlots[slotName] is null)
                return null;

            if (EquipmentSlots[slotName].ItemInstance!.Use()
                   is List<IAffectConditionally<IAffectableCharacter>> effectList)
            {
                foreach (var effect in effectList)
                {
                    effect.SetTarget(Owner);
                    effect.Remove();
                }
            }

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
    }
}
