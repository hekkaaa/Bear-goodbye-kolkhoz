using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class ContactLecturerInsertInputModel
    {
        public ContactType contactType { get; set; }
        public string Value { get; set; }
    }
}
