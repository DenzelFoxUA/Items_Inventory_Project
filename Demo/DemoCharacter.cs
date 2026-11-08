
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CharacterMainLib;

namespace InventoryCoreLib
{

    /// <summary>
    /// Demo-verison of a class using Grid as Inventory.
    /// </summary>
    public class DemoCharacter : Character, IDemoCharacter
    {

        public bool IsItemEqupped = false;

        private DemoInventory? _myInventory = null;

        private DemoEquipmentContainer? _myEquipment = null;

        private EffectsManager<IAffectableCharacter> effectsManager;


        protected override IEquipmentHandler<IEquipable>? EquipmentSection => _myEquipment;

        protected override IInventoryHandler<IUsable>? InventorySection => _myInventory;

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

        public void GetItem(IUsable? item)
        {
            if (item is null || InventorySection is null)
                return;

            InventorySection.AddItem(item);
        }

        public void UseItem(IUsable? item, IAffectable? target)
        {
            if (item is null)
                return;

            if (ReferenceEquals(item.MyOwner, target))
            {
                SetItemTarget(ref item, this);

                if (item.Use() is not List<IAffectImmediately<IAffectableCharacter>> effects)
                    return;

                foreach (var effect in effects)
                {
                    effect.Apply();
                }
            }
        }

        public void UseItem(Position itemPos, IAffectable? target)
        {
            if (_myInventory is null)
                throw new NullReferenceException("INVENTORY::NULL::ERR");

            var _item = _myInventory.ItemAt(itemPos);

            if(_item is null)
            {
                return;
            }

            if(_item is IStackable stackable && stackable.CurrentStackCount > 1)
            {
                stackable.RemoveFromStack(1);
                UseItem(_item, target);
            }
            else
            {
                var item = _myInventory.RemoveItem(itemPos);
                UseItem(item, target);
            }
            
        }

        public void CastSpell(uint manaSpent)
        {
            VitalStats["Mana"].Decrease(manaSpent);
        }

        public void OpenInventory()
        {
            if (InventorySection is null)
                throw new NullReferenceException("INVENTORY::NULL::ERR");

            Console.Write(InventorySection.ShowInventory());
        }

        public override void Move<DirVector>(DirVector? directionVector) where DirVector : default
        {
            Console.WriteLine($"{Name} - moving");
        }

        public void Update(float deltaTime)
        {
            effectsManager.Update(deltaTime);
        }

        public void SetItemTarget(ref IUsable item, IAffectableActor? target)
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

        public bool TryEquip(IEquipable item)
        {
            throw new NotImplementedException();
        }

        IEquipable? ICanUseEquipment<IEquipable>.Unequip(string slotName)
        {
            throw new NotImplementedException();
        }

        public object? UseTool(IEquipable item, IAffectable? target)
        {
            throw new NotImplementedException();
        }

        public IEquipable? DropItem(IEquipable item)
        {
            throw new NotImplementedException();
        }

        public void DoNothing()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateVitalsByStats()
        {
            throw new NotImplementedException();
        }

        protected override void UpdateMovespeedByStats()
        {
            throw new NotImplementedException();
        }

    }
}
