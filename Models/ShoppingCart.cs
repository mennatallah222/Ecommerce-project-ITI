using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Models
{
    public class ShoppingCart
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public virtual AppUser? AppUser { get; set; }
        [Required]
        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
