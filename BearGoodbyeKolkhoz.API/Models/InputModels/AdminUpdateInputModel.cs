using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class AdminUpdateInputModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDay { get; set; }
        public string Email { get; set; }
     
    }
}
