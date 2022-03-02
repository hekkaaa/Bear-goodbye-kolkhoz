using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class ClientOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public bool IsDeleted { get; set; }
        public Gender Gender { get; set; }
    }
}