using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.API.Models.OutputModels
{
    public class LecturerOutputModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? BirthDay { get; set; }
        public bool IsDeleted { get; set; }
        public Gender Gender { get; set; }
    }
}