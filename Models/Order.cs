using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public int UserId { get; set; }

        public virtual AppUser? AppUser { get; set; }

        [Required]
        public int ProductId { get; set; }

        public virtual Product? Product { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
        public int Quantity { get; set; }
    }

}
