using BearGoodbyeKolkhozProject.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        [StringLength(40)]
        public string? LastName { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? BirthDay { get; set; }

    }
}
