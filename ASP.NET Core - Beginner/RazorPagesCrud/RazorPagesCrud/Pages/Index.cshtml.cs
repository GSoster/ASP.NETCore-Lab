using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCrud.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }


        public IList<Customer> Customers { get; private set; }

        public async Task OnGetAsync()
        {
            //AsNoTracking is useful for reading scenarios, 
            Customers = await _db.Customers.AsNoTracking().ToListAsync();
        }

        
    }
}
