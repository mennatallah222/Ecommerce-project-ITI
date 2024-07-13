using Microsoft.AspNetCore.Identity;
using project01.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Models
{
    public class AppUser:IdentityUser
    {
        [UniqueUserName]
        [Required, MaxLength(100)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [Required, MaxLength(100)]
        [DataType(DataType.Text)]
        public string LastName { get; set; }
        [Required]
        [Range(18, int.MaxValue, ErrorMessage ="Age must be greater than 18")]
        public int Age { get; set; }
        public string? Address { get; set; }
        public byte[] ProfilePicture { get; set; }
    }
}
