using System.ComponentModel.DataAnnotations;

namespace Library.Web.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]  
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
