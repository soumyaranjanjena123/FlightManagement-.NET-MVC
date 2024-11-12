using System.ComponentModel.DataAnnotations;

namespace AirlineManagement.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "Fisrt name is require")]
        [MaxLength(255)]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "LastName is require")]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "UerName is required")]
        [MaxLength(50)]
        [Key]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]

        [MaxLength(50)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your mail.")]
        [MaxLength(150)]
        public string Email { get; set; }

    }
}
