using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTodo.Constants;

namespace AspNetCoreTodo.Controllers{
    [Authorize(Roles = Constant.AdministratorRole)]
    public class ManageUsersController : Controller
    {
        
        private readonly UserManager<IdentityUser> _userManager;

        public ManageUsersController(UserManager<IdentityUser> userManager)    
        {
            _userManager = userManager;
        }

        /* public async Task<IActionResult> Index()
        {
            var admins = (await _userManager
            .GetUsersInRoleAsync(Constant.AdministratorRole)
            //.ToArray();
            )
        }*/



    }
}