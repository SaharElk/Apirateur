using Apirateur.Infrastructure.ValidationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Apirateur.Models.Forms.Contact
{
    public class CreateContactForm
    {
        [Required]
        [StringLength(75)]
        public string LastName { get; set; }

        [Required]
        [StringLength(75)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(384)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [CategoryIdValidation]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}
