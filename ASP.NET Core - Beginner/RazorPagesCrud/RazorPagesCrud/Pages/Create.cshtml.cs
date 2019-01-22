using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace RazorPagesCrud.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _db;

        [TempData]
        public string Message { get; set; } //Temporary Data "message" to be displayed to the user

        [BindProperty]//makes this customer object filled out with the form information
        public Customer Customer { get; set; }

        private ILogger<CreateModel> _log;

        public CreateModel (AppDbContext db, ILogger<CreateModel> log)
        {
            _db = db;
            _log = log;
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();//return a page is an action
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            var msg = $"Customer {Customer.Name} Added!";
            Message = msg;
            _log.LogCritical(msg);
            return RedirectToPage("/Index");
        }
    }
}