

using System.Collections;
using System.Collections.Generic;

namespace InventoryCoreLib
{
    public struct InventorySize
    { 
        public ushort Rows { get; init; }
        public ushort Columns { get; init; }

        public InventorySize(ushort rows, ushort cols)
        {
            Rows = rows;
            Columns = cols;
        }
    }

    public struct Position
    {
        public ushort Row { get; init; }
        public ushort Column { get; init; }

        public Position(ushort row, ushort col)
        {
            Row = row;
            Column = col;
        }
    }

    public abstract class InventoryDefault<T, P> : IInventory<T, P>
        where T: class
    {
        protected InventorySize InventoryGrid { get; init; }

        public T[,] Container { get; }

        public InventoryDefault(InventorySize body)
        {
            if(body.Rows > 0 && body.Columns > 0)
            {
                InventoryGrid = body;
            }
            else
            {
                throw new System.ArgumentException("Size of a body must be > 0");
            }

            Container = new T[body.Rows, body.Columns]; 
        }

        public abstract bool AddItem(T item, P pos);

        public abstract T? RemoveItem(P pos);

        public abstract void SwapItems(P one, P two);

        public abstract bool AddItem(T item);

        public abstract T? RemoveItem(T item);

        public abstract void SwapItems(T one, T two);

        public abstract IEnumerator<T> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
