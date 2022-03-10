using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models.OutputModels
{
    public class AdminOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDay { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
    }
}
