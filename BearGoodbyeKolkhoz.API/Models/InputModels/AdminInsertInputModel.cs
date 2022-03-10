using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class AdminInsertInputModel : AdminUpdateInputModel
    {
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Password обязателен для ввода!")]
        [MinLength(6, ErrorMessage = "Не меньше 6 знаков!")]
        public string Password { get; set; }
    }
}
