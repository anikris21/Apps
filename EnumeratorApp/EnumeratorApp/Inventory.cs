using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumeratorApp
{
    internal class Inventory
    {
        public string Name;
        private string Description;
        public int Price;


        public Inventory(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }

    // foreach support
    internal class InventoryItems : IEnumerable
    {
        private Inventory[] _inventoryItems;

        public InventoryItems(Inventory[] inventories)
        {
            _inventoryItems = new Inventory[inventories.Length];
            for(int i = 0; i < inventories.Length; i++)
            {
                _inventoryItems[i] = inventories[i];
            }
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    internal class InventoryItemEnum : IEnumerator
    {
        //private Inventory _inventory;
        private Inventory[] _inventoryItems;

        private int position = -1;

        public InventoryItemEnum(Inventory[] inventories)
        {
            _inventoryItems = inventories;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _inventoryItems[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return position >= _inventoryItems.Length;

        }

        public void Reset()
        {
            position = -1;
        }
    }
}
