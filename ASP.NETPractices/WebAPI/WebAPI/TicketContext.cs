using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

using Microsoft.EntityFrameworkCore;
namespace WebAPI
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options):base(options)
        {

        }

        DbSet<TicketItem> TicketItems { get; set; }
    }
}
