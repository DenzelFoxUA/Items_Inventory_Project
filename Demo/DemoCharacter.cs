
using System;
using System.Collections.Generic;
using CharacterMainLib;

namespace InventoryCoreLib
{
    public class DemoInventory :
        InventoryDefault<BaseItemInstance, Position>
    {
        public DemoInventory(InventorySize body) : base(body)
        {
        }

        public override bool AddItem(BaseItemInstance? item, Position pos)
        {
            if (item is null)
                return false;

            if (Container[pos.Row, pos.Column] is not null)
                return false;

            Container[pos.Row, pos.Column] = item;
            return true;
        }

        public override bool AddItem(BaseItemInstance item)
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

        public override IEnumerator<BaseItemInstance> GetEnumerator()
        {
            foreach (BaseItemInstance? item in Container)
            {
                if (item is not null)
                    yield return item;
            }
        }

        public override BaseItemInstance? RemoveItem(Position pos)
        {
            if (Container[pos.Row, pos.Column] is not null)
            {
                return Container[pos.Row, pos.Column];
            }

            return default; //повертає null оскільки T - class
        }

        public override BaseItemInstance? RemoveItem(BaseItemInstance searchItem)
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
            BaseItemInstance? buffer = Container[one.Row, one.Column];
            Container[one.Row, one.Column] = Container[two.Row, two.Column];
            Container[two.Row, two.Column] = buffer;
        }

        public override void SwapItems(ref BaseItemInstance? one, ref BaseItemInstance? two)
        {
            CommonFunctions.Swap(ref one, ref two);
        }

        public string ShowInventory()
        {
            string result = "";

            const int columnWidth = 20;

            for (int y = 0; y < InventoryGrid.Rows; y++)
            {
                for (int x = 0; x < InventoryGrid.Columns; x++)
                {
                    string name = Container[x, y]?.Definition.Name ?? "[ EMPTY ]";

                    result += $"{name,-columnWidth}";
                }

                result += "\n\n";
            }


            return result;
        }
    }

    /// <summary>
    /// Demo-verison of a class using Grid as Inventory.
    /// </summary>
    public class DemoCharacter : Character<BaseItemInstance, Position>
    {

        private DemoInventory CurrentInventory => (DemoInventory)Inventory;  

        public DemoCharacter(
            string name, 
            uint maxLevel, 
            uint minAttributeValue, 
            uint attributesMaxValue,
            in IReadOnlyDictionary<string, VitalsBaseValues> vitals, 
            in IEnumerable<string> attributes,
            in IEnumerable<string> equipBlockNames,
            DemoInventory inventoryClass) 
            : base(name, 
                  maxLevel, 
                  minAttributeValue, 
                  attributesMaxValue, 
                  vitals, 
                  attributes,
                  equipBlockNames,
                  inventoryClass)
        {}

        public override void UseItem(BaseItemInstance? item)
        {
            if (item is null)
                return;

            if (item.Use() is List<BaseEffect> effects)
            {
                if (effects is not null)
                {
                    foreach (var effect in effects)
                    {
                        effect.Apply();
                    }
                }
            }
        }

        public override void UseItem(Position itemPos)
        {
            var item = CurrentInventory.RemoveItem(itemPos);

            if(item is not null)
            {
                var result = item.Use();

                if(result is List<BaseEffect> effects)
                {
                    if (effects is not null)
                    {
                        foreach (var effect in effects)
                        {
                            effect.Apply();
                        }
                    }
                }
            }
            
        }

        public void CastSpell(uint manaSpent)
        {
            VitalStats["Mana"].Decrease(manaSpent);
        }

        public void OpenInventory()
        {
            Console.Write(CurrentInventory.ShowInventory());
        }
    }
}
