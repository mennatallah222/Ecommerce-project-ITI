using project01.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace project01.Validations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class UniqueUserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var dbContext = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
                var existingUser = dbContext.Users.SingleOrDefault(u =>
                    u.FirstName == validationContext.ObjectType.GetProperty("FirstName").GetValue(validationContext.ObjectInstance).ToString() &&
                    u.LastName == value.ToString()
                );

                if (existingUser != null)
                {
                    return new ValidationResult("The username already exists");
                }
            }

            return ValidationResult.Success;
        }
    }
}