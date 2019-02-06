using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace WebAPI.Models
{
    public class TicketItem
    {
        public long Id{ get; set; }
        [Required]
        public string Concert { get; set; }
        public string Artist { get; set; }
        public bool Available { get; set; }
    }
}
