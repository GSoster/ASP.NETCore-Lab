using System;
using System.Collections.Generic;
using System.Linq;
using Practices.Models;
using System.Threading.Tasks;
namespace Practices.Services
{

    public class LocalItemService : IItemService
    {
        public IEnumerable<Item> GetAllItems()
        {
            Item item1 = new Item();
            item1.Name = "Item 1";
            Item item2 = new Item {Name = "Item 2"};
            Item item3 = new Item(){Name = "Item 3"};
            return new List<Item>{
                item1,
                item2,
                item3,
                new Item{Name = "Item 4"}
            };
        }
        public async Task<Item[]> GetAllItemsAsync()
        {
            return GetAllItems().ToArray();
        }
    }

}