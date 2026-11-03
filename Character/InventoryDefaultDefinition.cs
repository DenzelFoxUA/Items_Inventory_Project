

namespace InventoryCoreLib
{
    public struct InventorySize
    { 
        public ushort Rows { get; init; }
        public ushort Columns { get; init; }
    }

    public class InventoryDefaultDefinition<T> : IInventory<T>
        where T: class
    {
        protected InventorySize InventoryGrid { get; init; }

        public T[,] Container { get; }

        public InventoryDefaultDefinition(InventorySize body)
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

        public bool AddItem(T item, Position pos)
        {
            if (Container[pos.Row, pos.Column] != null)
                return false;

            Container[pos.Row, pos.Column] = item;
            return true;
        }

        public T? RemoveItem(Position pos)
        {
            if (Container[pos.Row, pos.Column] != null)
            {
                return Container[pos.Row,pos.Column];
            }
               
            return default; //повертає null оскільки T - class
        }

        public void SwapItems(Position one, Position two)
        {
            T? buffer = Container[one.Row,one.Column];
            Container[one.Row, one.Column] = Container[two.Row, two.Column];
            Container[two.Row, two.Column] = buffer;

        }
    }
}
