using System.ComponentModel.DataAnnotations;

namespace AirlineManagement.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UerName is required")]
        [MaxLength(50)]
        [Key]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]

        [MaxLength(50)]
        public string Password { get; set; }

    }
}
