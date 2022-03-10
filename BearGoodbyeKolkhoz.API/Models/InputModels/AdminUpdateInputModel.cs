using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class AdminUpdateInputModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Email обязателен для ввода!")]
        [EmailAddress]
        public string Email { get; set; }

    }
}
