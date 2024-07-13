using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required]
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
