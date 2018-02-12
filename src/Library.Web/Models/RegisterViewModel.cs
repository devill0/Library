using Library.Core.Dto;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }

        [Required]
        public RoleDto Role { get; set; }
    }
}
