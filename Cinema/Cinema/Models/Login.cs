using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class LogIn
    {
        [Required]
        [MinLength(5, ErrorMessage = "Min Length = 5 at least")]
        [DisplayName("Login")]
        public string Login { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Min Length = 5 at least")]
        [DisplayName("Password")]
        public string Pass { get; set; }

    }
}