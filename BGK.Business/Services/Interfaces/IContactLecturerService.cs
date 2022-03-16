using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services.Interfaces
{
    public interface IContactLecturerService
    {
        void AddContact(int lecturerId, ContactLecturerModel сontactLecturerModel);

        void UpdateContact(int id, ContactLecturerModel сontactLecturerModel);
    }
}
