using CharacterMainLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryCoreLib
{
    public class DemoInventory :
        InventoryGridArray<IOwnedUsable>
    {

        private IDemoCharacter _owner;
        public IDemoCharacter Owner { get => _owner; }

        private void ValidatePosition(Position pos)
        {
            if (pos.Row < 0 || pos.Row >= InventoryGrid.Rows ||
                pos.Column < 0 || pos.Column >= InventoryGrid.Columns)
            {
                throw new ArgumentOutOfRangeException(nameof(pos));
            }
        }

        private static bool CanStack(IUsable? existing, IUsable? incoming)
        {
            return existing is IStackable &&
                   incoming is IStackable &&
                   !ReferenceEquals(existing, incoming) &&
                   existing.Equals(incoming);
        }

        public DemoInventory(InventorySize body, IDemoCharacter owner) : base(body)
        {
            _owner = owner;
        }

        public override IOwnedUsable? AddItem(IOwnedUsable? item, Position pos)
        {
            if (item is null)
                return null;

            ValidatePosition(pos);

            if (item is IStackable _itStackable &&
                _itStackable.CurrentStackCount == 0)
            {
                return item;
            }

            IUsable? existing = Container[pos.Row, pos.Column];

            // Порожня клітинка
            if (existing is null)
            {
                Container[pos.Row, pos.Column] = item;
                return null;
            }

            // Предмети не можна об'єднати
            if (!CanStack(existing, item))
                return item;

            IStackable existingStack = (IStackable)existing;
            IStackable incoming = (IStackable)item;

            uint previousCount = incoming.CurrentStackCount;

            // AddToStack повертає кількість, яка не помістилася
            uint remaining = existingStack.AddToStack(previousCount);

            if (remaining > previousCount)
                throw new InvalidOperationException("AddToStack returned an invalid remainder.");

            incoming.RemoveFromStack(previousCount - remaining);

            return remaining == 0 ? null : item;
        }

        #region [! ADD ITEM !]

        public override IOwnedUsable? AddItem(IOwnedUsable item)
        {
            if (item is null)
                throw new ArgumentNullException("Cant add item - it is null");

            // Спочатку намагаємося об'єднати стеки
            if (item is IStackable _itStackable)
            {
                if (_itStackable.CurrentStackCount == 0)
                    return item;

                for (int row = 0; row < InventoryGrid.Rows; row++)
                {
                    for (int col = 0; col < InventoryGrid.Columns; col++)
                    {
                        IUsable? existing = Container[row, col];

                        if (!CanStack(existing, item))
                            continue;

                        IStackable existingStack = (IStackable)existing!;

                        uint previousCount = _itStackable.CurrentStackCount;

                        uint remaining = existingStack.AddToStack(previousCount);

                        if (remaining > previousCount)
                            throw new InvalidOperationException("AddToStack returned an invalid remainder.");

                        _itStackable.RemoveFromStack(previousCount - remaining);

                        if (remaining == 0)
                            return null;
                    }
                }
            }

            // Шукаємо порожню клітинку для будь-якого предмета
            for (int row = 0; row < InventoryGrid.Rows; row++)
            {
                for (int col = 0; col < InventoryGrid.Columns; col++)
                {
                    if (Container[row, col] is null)
                    {
                        SetThisAsItemOwner(ref item!);
                        Container[row, col] = item;
                        return null;
                    }
                }
            }

            // Інвентар заповнений
            return item;
        }

        #endregion

        public override IEnumerator<IOwnedUsable> GetEnumerator()
        {
            foreach (IOwnedUsable? item in Container)
            {
                if (item is not null)
                    yield return item;
            }
        }

        #region [! REMOVE !]

        public override IOwnedUsable? RemoveItem(Position pos)
        {
            ValidatePosition(pos);

            IOwnedUsable? result = Container[pos.Row, pos.Column];

            Container[pos.Row, pos.Column] = null;

            return result;
        }

        public override IOwnedUsable? RemoveItemBySearch(IOwnedUsable searchItem)
        {
            if (searchItem is null)
                return null;

            for (ushort row = 0; row < InventoryGrid.Rows; row++)
            {
                for (ushort col = 0; col < InventoryGrid.Columns; col++)
                {
                    if (Container[row, col] == searchItem)
                    { 
                        return RemoveItem(new Position(row,col));
                    }
                }
            }

            return null;
        }
        #endregion

        #region [ SWAP ]

        //це переміщує всередині інвентаря
        public override void SwapItems(Position one, Position two)
        {
            ValidatePosition(one);
            ValidatePosition(two);

            SwapItems(ref Container[one.Row, one.Column], ref Container[two.Row, two.Column]);
        }

        //це потенційно використовується для свапання екіпірування, коли зброї наприклад слот зайнятий
        public override void SwapItems(ref IOwnedUsable? one, ref IOwnedUsable? two)
        {
            CommonFunctions.Swap(ref one, ref two);
        }

        #endregion

        public override string ShowInventory()
        {
            StringBuilder result = new();

            const int cellWidth = 20;

            for (int row = 0; row < InventoryGrid.Rows; row++)
            {
                for (int col = 0; col < InventoryGrid.Columns; col++)
                {
                    IUsable? item = Container[row, col];

                    string content;

                    if (item is IStackable stackable)
                    {
                        content = $"[{stackable.GetDefinitionName()} x{stackable.CurrentStackCount}]";
                    }
                    else if (item is not null)
                    {
                        content = $"[{item.GetDefinitionName()}]";
                    }
                    else
                    {
                        content = $"[ {row},{col} ]";
                    }

                    result.Append($"{content,-cellWidth}");
                }

                result.AppendLine();
            }

            return result.ToString();
        }

        public override IOwnedUsable? ItemAt(Position position)
        {

            ValidatePosition(position);

            if (Container[position.Row, position.Column] is not null)
                return Container[position.Row, position.Column];
            else
                return null;
        }

        #region [ ITEMS OWNERSHIP ]

        public override void SetThisAsItemOwner(ref IOwnedUsable? item)
        {
            if (item is null || _owner is null)
                return;

            if (ReferenceEquals(item.MyOwner, _owner))
                return;

            item.SetMyOwner(_owner);

        }

        public override void RemoveItemOwnership(ref IOwnedUsable? item)
        {
            if (item is null) return;

            item.SetMyOwner(null);
        }

        #endregion
    }
}
