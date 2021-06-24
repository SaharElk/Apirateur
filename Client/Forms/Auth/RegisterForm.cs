using Client.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Forms.Auth
{
    public class RegisterForm
    {
        [Required]
        [MaxLength(75)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(75)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(384)]
        [EmailAddress]
        [EmailExistsValidation]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
