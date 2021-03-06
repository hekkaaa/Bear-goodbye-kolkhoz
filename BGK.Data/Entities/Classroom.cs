using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Classroom")]
    public class Classroom
    {
        public int Id { get; set; }
        public int MembersCount { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public bool IsDeleted { get; set; }
    }
}
