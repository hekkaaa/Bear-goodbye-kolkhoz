using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class CompanyInsertInputModel : CompanyUpdateInputModel
    {
        [Required(ErrorMessage = "Email обязателен для ввода!")]
        [EmailAddress]
        //[MinLength(4)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password обязателен для ввода!")]
        [MinLength(6, ErrorMessage = "Не меньше 6 знаков!")]
        public string Password { get; set; }
    }
}
