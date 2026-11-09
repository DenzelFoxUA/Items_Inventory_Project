
using CharacterMainLib;
using System;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    /// <summary>
    /// Demo-verison of a class using Grid as Inventory.
    /// </summary>
    public class DemoCharacter : Character<IOwnedUsable, IOwnedEquipable>, IDemoCharacter
    {

        public bool IsItemEqupped = false;

        private DemoInventory? _myInventory = null;

        private DemoEquipmentContainer? _myEquipment = null;

        private EffectsManager<IAffectableCharacter> effectsManager;


        protected override IEquipmentHandler<IOwnedEquipable>? EquipmentSection => _myEquipment;

        protected override IInventoryHandler<IOwnedUsable>? InventorySection => _myInventory;

        public DemoCharacter(
            string name,
            CharacterBase baseFeatures,
            InventorySize size,
            in IReadOnlyDictionary<string, VitalsBaseValues> vitals, 
            in IEnumerable<string> attributes,
            in IEnumerable<string> equipBlockNames) 
            : base(name,  
                  baseFeatures,
                  vitals, 
                  attributes,
                  equipBlockNames)
        {
            effectsManager = new EffectsManager<IAffectableCharacter>(this);
            _myInventory = new DemoInventory(size,this);
            _myEquipment = new DemoEquipmentContainer(this, equipBlockNames);
        }

        public void PickUpItem(IOwnedUsable? item)
        {
            if (item is null || InventorySection is null)
                return;

            InventorySection.AddItem(item);
        }

        void ICanUseItems<IOwnedUsable>.UseItem(IOwnedUsable? item, IAffectableActor? target)
        {
            if (item is null || target is null)
                return;

            UseItem(item, target);
        }

        public void UseItem(Position itemPos, IAffectableActor? target)
        {
            if (_myInventory is null)
                throw new NullReferenceException("INVENTORY::NULL::ERR");

            var _item = _myInventory.ItemAt(itemPos);

            if (_item is null || target is null) return;

            if(_item is IStackable stackable && stackable.CurrentStackCount > 1)
            {
                stackable.RemoveFromStack(1);
                UseItem(_item, target);
            }
            else
            {
                var item = _myInventory.RemoveItem(itemPos);

                if (item is null)
                    return;

                UseItem(item, target);
            }
            
        }

        public void OpenInventory()
        {
            if (InventorySection is null)
                throw new NullReferenceException("INVENTORY::NULL::ERR");

            if (EquipmentSection is null)
                throw new NullReferenceException("EQUIPMENT::NULL::ERR");


             Console.WriteLine(EquipmentSection.ShowEquipment());

             Console.WriteLine();

             Console.WriteLine(InventorySection.ShowInventory());


        }

        public override void Move<DirVector>(DirVector? directionVector) where DirVector : default
        {
            Console.WriteLine($"{Name} - moving");
        }

        public void Update(float deltaTime)
        {
            effectsManager.Update(deltaTime);
        }

        void ICanUseItems<IOwnedUsable>.SetItemTarget(ref IOwnedUsable item, IAffectableActor? target)
        {
            if (item is null || target is null)
                return;

            SetItemTarget(ref item, target);
        }

        #region [ Equip ]

        public void Equip(IOwnedEquipable item)
        {
            if (EquipmentSection is null)
                throw new NullReferenceException("EQUIPMENT::NULL::ERROR");

            if (item is null)
                return;

            bool isOk = EquipmentSection.TryEquipIntoSlot(ref item);

            if (isOk)
                Console.WriteLine("ItemEquiped!");
        }

        public IOwnedEquipable? Unequip(string slotName)
        {
            var item = EquipmentSection!.UnequipFromSlot(slotName);

            if (InventorySection is null)
                throw new NullReferenceException("INVNTORY::NULL::ERROR");

            if (item is null)
                return null;

            var notFit = InventorySection!.AddItem(item);

            if (notFit is not null && notFit is IOwnedEquipable _item)
                return _item;

            return null;
        }

        #endregion

        public IOwnedEquipable? DropItem(IOwnedEquipable item)
        {
            throw new NotImplementedException();
        }

        public void DoNothing()
        {
            return;
        }

        void IDemoCharacter.UseConsumable(IOwnedUsable? consumable)
        {
            if(consumable is not null)
                UseConsumable(consumable);
        }

        #region [ CAPSULE ]

        private void SetItemTarget(ref IOwnedUsable item, IAffectableActor? target)
        {
            if (target is IAffectableCharacter _char)
            {
                item.SetMyTarget(_char);
            }
            else
            {
                item.SetMyTarget(target);
            }
        }


        #region [ UPDATE CHARACTER ]

        protected override void UpdateVitalsByStats()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateMovespeedByStats()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region [ USE ITEMS ]

        private void UseItem(IOwnedUsable item, IAffectableActor target)
        {
            if (target is IAffectableCharacter character)
            {
                SetItemTarget(ref item, character);
            }
            else
            {
                SetItemTarget(ref item, target);
            }

            item.Use();
        }

        private void UseConsumable(IOwnedUsable consumable)
        {

            if (consumable.GetEffects() is IReadOnlyList<IAffectImmediately<IAffectableCharacter>> effects)
            {
                foreach (var effect in effects)
                {
                    effect.Apply();
                }
                Console.WriteLine("Consumable used!");
                Console.ReadLine();
            }

        }

        #endregion

        #region [ Equip ]


        #endregion

        #endregion

    }
}
