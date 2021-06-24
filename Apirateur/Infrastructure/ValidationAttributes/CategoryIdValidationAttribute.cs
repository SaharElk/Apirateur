using Client.Data;
using Client.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apirateur.Infrastructure.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CategoryIdValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ICategoryRepository categoryRepository = (ICategoryRepository)validationContext.GetService(typeof(ICategoryRepository));

            Category category = categoryRepository.Get().Where(category => category.Id == (int)value).SingleOrDefault();

            if (category is null)
            {
                return new ValidationResult("Invalid category");
            }

            return ValidationResult.Success;
        }
    }
}
