using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class CompanyInsertInputModel : CompanyUpdateInputModel
    {
        [Required(ErrorMessage = "Email обязателен для ввода!")]
        [MaxLength(25, ErrorMessage = "Email длинный!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password обязателен для ввода!")]
        [MaxLength(25, ErrorMessage = "Не меньше 6 знаков!")]
        public string Password { get; set; }
    }
}
