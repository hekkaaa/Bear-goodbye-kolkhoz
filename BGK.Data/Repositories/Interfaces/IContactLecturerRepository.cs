using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IContactLecturerRepository
    {
        void AddContact(ContactLecturer contact);
        void UpdateContact(ContactLecturer contactLecturer, ContactLecturer contact);
        ContactLecturer GetValueContactLecturerById(int id);
    }
}