
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using CharacterMainLib;

namespace InventoryCoreLib
{
    public class DemoInventory :
        InventoryGridArray<BaseItemInstance>
    {
        public DemoInventory(InventorySize body) : base(body)
        {
        }

        public override BaseItemInstance? AddItem(BaseItemInstance? item, Position pos)
        {
            if (item is null)
                return null;

            if (pos.Row < 0 || pos.Row >= InventoryGrid.Rows ||
                pos.Column < 0 || pos.Column >= InventoryGrid.Columns)
                throw new ArgumentOutOfRangeException(nameof(pos));

            BaseItemInstance? existing = Container[pos.Row, pos.Column];

            // Клітинка порожня
            if (existing is null)
            {
                Container[pos.Row, pos.Column] = item;
                return null;
            }

            // Предмети різні або це той самий екземпляр
            if (ReferenceEquals(existing, item) || existing != item)
                return item;

            // Об'єднуємо стеки
            uint remaining = existing.AddToStack(item.CurrentStackCount);

            // Віднімаємо перенесену кількість
            item.RemoveFromStack(item.CurrentStackCount - remaining);

            return remaining == 0 ? null : item;
        }

        public override BaseItemInstance? AddItem(BaseItemInstance item)
        {
            uint remaining = item.CurrentStackCount;

            if (remaining == 0)
                return null;

            // 1. Дозаповнюємо існуючі стеки
            for (int row = 0; row < InventoryGrid.Rows; row++)
            {
                for (int col = 0; col < InventoryGrid.Columns; col++)
                {
                    BaseItemInstance? existing = Container[row, col];

                    if (existing is null ||
                        ReferenceEquals(existing, item) ||
                        existing != item)
                        continue;

                    remaining = existing.AddToStack(remaining);

                    if (remaining == 0)
                        break;
                }

                if (remaining == 0)
                    break;
            }

            // Віднімаємо кількість, перенесену в існуючі стеки
            item.RemoveFromStack(item.CurrentStackCount - remaining);

            if (remaining == 0)
                return null;

            // 2. Шукаємо вільну клітинку
            for (int row = 0; row < InventoryGrid.Rows; row++)
            {
                for (int col = 0; col < InventoryGrid.Columns; col++)
                {
                    if (Container[row, col] is null)
                    {
                        Container[row, col] = item;
                        return null;
                    }
                }
            }

            // 3. Місця немає — повертаємо залишок
            return item;
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
                var result = Container[pos.Row, pos.Column];

                Container[pos.Row, pos.Column] = null;

                return result;
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


        //це переміщує всередині інвентаря
        public override void SwapItems(Position one, Position two)
        {
            BaseItemInstance? buffer = Container[one.Row, one.Column];
            Container[one.Row, one.Column] = Container[two.Row, two.Column];
            Container[two.Row, two.Column] = buffer;
        }

        //це потенційно використовується для свапання екіпірування, коли зброї наприклад слот зайнятий
        public override void SwapItems(ref BaseItemInstance? one, ref BaseItemInstance? two)
        {
            CommonFunctions.Swap(ref one, ref two);
        }


        public override string ShowInventory()
        {
            string result = "";

            const int cellWidth = 12;

            for (int x = 0; x < InventoryGrid.Rows; x++)
            {
                for (int y = 0; y < InventoryGrid.Columns; y++)
                {
                    string content = Container[x, y] is not null
                        ? $"[{Container[x, y]!.Definition.Name} x{Container[x, y]!.CurrentStackCount}]"
                        : $"[ {x},{y} ]";

                    result += $"{content,-cellWidth}";
                }

                result += "\n";
            }


            return result;
        }

        public override BaseItemInstance? ItemAt(Position position)
        {

            if (Container[position.Row, position.Column] is not null)
                return Container[position.Row, position.Column];
            else
                return null;
        }
    }

    /// <summary>
    /// Demo-verison of a class using Grid as Inventory.
    /// </summary>
    public class DemoCharacter : Character<BaseItemInstance>
    {

        private DemoInventory CurrInventory => (DemoInventory)Inventory;

        public List<IAffect<IAffectableCharacter>> ActiveEffects { get; }

        public DemoCharacter(
            string name,
            CharacterBase baseFeatures,
            in IReadOnlyDictionary<string, VitalsBaseValues> vitals, 
            in IEnumerable<string> attributes,
            in IEnumerable<string> equipBlockNames,
            DemoInventory inventoryClass) 
            : base(name,  
                  baseFeatures,
                  vitals, 
                  attributes,
                  equipBlockNames,
                  inventoryClass)
        {
            ActiveEffects = new List<IAffect<IAffectableCharacter>>();

        }

        public void GetItem(BaseItemInstance? item)
        {
            if (item is null)
                return;

            CurrInventory.AddItem(item);
        }

        public override void UseItem(BaseItemInstance? item, IAffectable? target)
        {
            if (item is null || target is null)
                return;

            if(target is IAffectableCharacter _target)
            {
                item.SetItemTarget(_target);

                if (item.Use() is List<IAffect<IAffectableCharacter>> effects)
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

        public void UseItem(Position itemPos, IAffectable? target)
        {
            var _item = CurrInventory.ItemAt(itemPos);

            if(_item is null)
            {
                return;
            }

            if(_item.CurrentStackCount > 1)
            {
                _item.RemoveFromStack(1);
                UseItem(_item, target);
            }
            else
            {
                var item = CurrInventory.RemoveItem(itemPos);
                UseItem(item, target);
            }
            
        }

        public void CastSpell(uint manaSpent)
        {
            VitalStats["Mana"].Decrease(manaSpent);
        }

        public void OpenInventory()
        {
            Console.Write(CurrInventory.ShowInventory());
        }

        public override void UseTool<T>(T? tool) where T : default
        {
            throw new NotImplementedException();
        }

        public override void Move<DirVector>(DirVector? directionVector) where DirVector : default
        {
            Console.WriteLine($"{Name} - moving");
        }
    }
}
