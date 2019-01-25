using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;//Where
using System.Threading.Tasks;//Task<>
using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Services;
using Microsoft.AspNetCore.Authorization;//Authorize
using Microsoft.AspNetCore.Identity;//userManager

[Authorize]
public class TodoController : Controller
{

    private readonly ITodoItemService _todoItemService;
    private readonly UserManager<IdentityUser> _userManager;

    public TodoController(ITodoItemService todoItemService, UserManager<IdentityUser> userManager)
    {
        _todoItemService = todoItemService;
        _userManager = userManager;
    }
    public async Task<IActionResult> Index()
    {
        var currentUser = await _userManager.GetUserAsync(User);
        if (currentUser == null) return Challenge();//goes to the login screen

        var items = await _todoItemService.GetIncompleteItemAsync(currentUser);
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

    public async Task<IActionResult> MarkDone(Guid id)
    {
        if (id == Guid.Empty)
        {
            return RedirectToAction("Index");
        }

        var successful = await _todoItemService.MarkDoneAsync(id);
        if (!successful)
        {
            return BadRequest("Could not mark item as done");
        }

        return RedirectToAction("Index");


    }


}