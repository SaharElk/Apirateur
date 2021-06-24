using Client.Repositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace Aspirateur.Infrastructure.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailExistsValidationAttribute : ValidationAttribute
    {
        // Exemple de validation avec IsValid(object value)

        //public override bool IsValid(object value)
        //{
        //    string email = value as string;
            
        //    return email != "haha@test.com";
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            IAuthRepository authRepository = (IAuthRepository)validationContext.GetService(typeof(IAuthRepository));

            string email = value as string;

            if (!string.IsNullOrWhiteSpace(email))
            {
                if (authRepository.EmailExists(email))
                {
                    return new ValidationResult("Email adress already exists");
                }
            }
            else
            {
                return new ValidationResult("Invalid email");
            }

            return ValidationResult.Success;
        }

    }
}
