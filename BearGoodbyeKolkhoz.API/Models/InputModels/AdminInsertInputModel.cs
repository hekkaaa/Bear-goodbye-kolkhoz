using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class AdminInsertInputModel : AdminUpdateInputModel
    {
        public Gender Gender { get; set; }
        public string Password { get; set; }
    }
}
