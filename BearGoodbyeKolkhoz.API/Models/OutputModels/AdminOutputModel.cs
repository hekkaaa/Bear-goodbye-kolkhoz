using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.API.Models.OutputModels
{
    public class AdminOutputModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
    }
}
