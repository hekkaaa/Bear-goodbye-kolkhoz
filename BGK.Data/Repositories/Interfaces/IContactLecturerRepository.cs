using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IContactLecturerRepository
    {
        void AddContact(ContactLecturer contact);
        void UpdateContactLecturerValueRepo(ContactLecturer contactLecturer);
        ContactLecturer GetValueContactLecturerById(int id);
    }
}