using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Ticket")]
    public class TicketController : Controller
    {
        public TicketContext _context;

        public TicketController(TicketContext context)
        {
            _context = context;
            if (_context.TicketItems.Count() == 0)
            {
                _context.TicketItems.Add(new TicketItem { Concert = "14 Bis" });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<TicketItem> GetAll()
        {
            //AsNoTracking is used when we want to just return, not keep track if the items change
            return _context.TicketItems.AsNoTracking().ToList();
        }

    }
}