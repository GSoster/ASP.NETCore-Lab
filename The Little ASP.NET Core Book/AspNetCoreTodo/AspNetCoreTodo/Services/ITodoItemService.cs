using System;
using AspNetCoreTodo.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemAsync(IdentityUser user);
        Task<bool> AddItemAsync(TodoItem newItem);

        Task<bool> MarkDoneAsync(Guid id);
    }
}
