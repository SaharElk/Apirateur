using Client.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailExistsValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;
            
            return email != "haha@test.com";
        }

        //protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        //{
        //    AuthService authService = (AuthService)validationContext.GetService(typeof(AuthService));



        //    return ValidationResult.Success;
        //}

    }
}
