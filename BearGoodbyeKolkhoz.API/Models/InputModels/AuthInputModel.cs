using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class AuthInputModel
    {
        [Required(ErrorMessage = "Email обязателен для ввода!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password обязателен для ввода!")]
        public string Password { get; set; }

    }
}
