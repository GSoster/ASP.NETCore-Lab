using System;
using System.ComponentModel.DataAnnotations;

namespace Practices.Models
{
    public class Item
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}