using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class RegistrationInputModel
    {
        [Required(ErrorMessage = "Email обязателен для ввода!")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password обязателен для ввода!")]
        [MinLength(6, ErrorMessage = "Не меньше 6 знаков!")]
        public string Password { get; set; }
    }
}
