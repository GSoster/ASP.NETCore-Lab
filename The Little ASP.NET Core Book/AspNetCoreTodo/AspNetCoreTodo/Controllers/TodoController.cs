using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
public class TodoController : Controller
{

    private readonly ITodoItemService _todoItemService;

    public TodoController(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }
    public async Task<IActionResult> Index()
    {
        var items = await _todoItemService.GetIncompleteItemAsync();
        var model = new TodoViewModel
        {
            Items = items
        };
        return View(model);
    }



    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddItem(TodoItem todoItem)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Index");
        }

        var successful = await _todoItemService.AddItemAsync(todoItem);
        if(!successful)
        {
            return BadRequest("Could not add item");
        }

        return RedirectToAction("Index");

    }


}