using System;
using AspNetCoreTodo.Models;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemAsync();
        Task<bool> AddItemAsync(TodoItem newItem);

    }
}
