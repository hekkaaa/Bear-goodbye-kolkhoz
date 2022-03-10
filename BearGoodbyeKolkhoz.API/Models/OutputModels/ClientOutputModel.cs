using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class ClientOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public bool IsDeleted { get; set; }
        public Gender Gender { get; set; }
    }
}