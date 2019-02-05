using System;
using Microsoft.AspNetCore.Mvc;
using Practices.Services;

namespace Practices.Controllers
{
    public class ItemsController : Controller
    {

        private readonly IItemService _repository;

        public ItemsController(IItemService repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            //return Ok("Meu Index");//first version
            //return View();//second version
            return Ok(_repository.GetAllItems());//third version
        }

    }
}