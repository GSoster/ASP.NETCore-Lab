using System;
using System.Collections.Generic;
using Practices.Models;
using System.Threading.Tasks;
namespace Practices.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetAllItems();
        Task<Item[]> GetAllItemsAsync();
    }
}