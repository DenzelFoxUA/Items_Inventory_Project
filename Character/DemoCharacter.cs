
using System;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public class DemoInventory :
        InventoryDefault<UsableItemInstance, Position>
    {
        public DemoInventory(InventorySize body) : base(body)
        {
        }

        public override bool AddItem(UsableItemInstance item, Position pos)
        {
            if (Container[pos.Row, pos.Column] != null)
                return false;

            Container[pos.Row, pos.Column] = item;
            return true;
        }

        public override bool AddItem(UsableItemInstance item)
        {
            for(short row = 0; row < InventoryGrid.Rows; row++)
            {
                for(short col = 0; col < InventoryGrid.Columns; col++)
                {
                    if (Container[row,col] == null)
                    {
                        Container[row, col] = item;
                        return true;
                    }
                }
            }

            return false;

        }

        public override IEnumerator<UsableItemInstance> GetEnumerator()
        {
            foreach (UsableItemInstance? item in Container)
            {
                if (item is not null)
                    yield return item;
            }
        }

        public override UsableItemInstance? RemoveItem(Position pos)
        {
            if (Container[pos.Row, pos.Column] != null)
            {
                return Container[pos.Row, pos.Column];
            }

            return default; //повертає null оскільки T - class
        }

        public override UsableItemInstance? RemoveItem(UsableItemInstance searchItem)
        {
            foreach(var item in Container)
            {
                if (item == searchItem)
                    return item;
            }

            return null;
        }

        public override void SwapItems(Position one, Position two)
        {
            UsableItemInstance? buffer = Container[one.Row, one.Column];
            Container[one.Row, one.Column] = Container[two.Row, two.Column];
            Container[two.Row, two.Column] = buffer;
        }

        public override void SwapItems(UsableItemInstance one, UsableItemInstance two)
        {
            UsableItemInstance? buffer = one;
            one = two;
            two = buffer;
        }
    }

    /// <summary>
    /// Demo-verison of a class using Grid as Inventory.
    /// </summary>
    public class DemoCharacter : Character<UsableItemInstance, Position>
    {

        public DemoCharacter(
            string name, 
            uint maxLevel, 
            uint minAttributeValue, 
            uint attributesMaxValue,
            in IReadOnlyDictionary<string, VitalsBaseValues> vitals, 
            in IEnumerable<string> attributes, 
            DemoInventory inventoryClass) 
            : base(name, 
                  maxLevel, 
                  minAttributeValue, 
                  attributesMaxValue, 
                  vitals, 
                  attributes, 
                  inventoryClass)
        {}

        public override void UseItem(UsableItemInstance? item)
        {
            if (item is null)
                return;

            var effects = item.Use();

            //
            Console.WriteLine($"Item: {item.UsableItem.Name} used");
            Console.ReadLine();
            //

            if (effects is not null)
            {
                foreach (var effect in effects)
                {
                    effect.Apply();
                }
            }
        }

        public override void UseItem(Position itemPos)
        {
            UseItem(Inventory.RemoveItem(itemPos));
        }

        public void CastSpell(uint manaSpent)
        {
            VitalStats["Mana"].Decrease(manaSpent);
        }
    }
}
