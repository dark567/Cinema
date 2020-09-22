using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class LogIn
    {
        [Required]
        [MinLength(5)]
        public string Login { get; set; }
        [Required]
        [MinLength(5)]
        public string Pass { get; set; }


    }
}