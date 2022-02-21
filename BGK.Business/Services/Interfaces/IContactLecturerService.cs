using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services.Interfaces
{
    public interface IContactLecturerService
    {
        void AddContactLecturerValue(ContactLecturerModel сontactLecturerModel);

        void UpdateContactLecturerValue(ContactLecturerModel сontactLecturerModel);
    }
}
