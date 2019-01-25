using System;
using AspNetCoreTodo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;//IdentityUser user
namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<TodoItem[]> GetIncompleteItemAsync(IdentityUser user)
        {
            return Task.FromResult(new TodoItem[]{
                new TodoItem{
                    Title = "Learn ASP.NET Core",
                    DueAt = DateTimeOffset.Now.AddDays(1)
                },
                new TodoItem{
                    Title = "Build awesome apps",
                    DueAt = DateTimeOffset.Now.AddDays(2)
                }
            });
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            return await Task.FromResult(true);
        }
        public Task<bool> AddItemAsync(TodoItem newItem)
        {
            return Task.FromResult(true);
        }


    }
}