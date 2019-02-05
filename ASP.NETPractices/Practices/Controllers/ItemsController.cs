using System;
using Microsoft.AspNetCore.Mvc;
namespace Practices.Controllers
{
    public class ItemsController : Controller
    {

        public IActionResult Index()
        {
            return Ok("Meu Index");
        }

    }
}