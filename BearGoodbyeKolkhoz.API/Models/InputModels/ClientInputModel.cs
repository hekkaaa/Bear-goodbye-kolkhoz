using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class ClientInputModel
    {
        [Required(ErrorMessage = "Name обязателен для ввода!")]
        [MaxLength(10)]
        [MinLength(2)]
        public string? Name { get; set; }
        [Required(ErrorMessage = "LastName обязателен для ввода!")]
        [MaxLength(10)]
        [MinLength(2)]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "BirthDay обязателен для ввода!")]
        public string? BirthDay { get; set; }
        
        public Gender Gender { get; set; }

    }
}