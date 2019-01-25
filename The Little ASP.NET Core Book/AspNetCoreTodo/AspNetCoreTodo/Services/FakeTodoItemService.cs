using System;
using AspNetCoreTodo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        public Task<TodoItem[]> GetIncompleteItemAsync()
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
    }
}