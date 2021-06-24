using System.ComponentModel.DataAnnotations;

namespace Apirateur.Models.Forms.Auth
{
    public class LoginForm
    {
        [Required]
        [MaxLength(384)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
