using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IContactLecturerRepository
    {
        void AddContactLecturerValueRepo(ContactLecturer сontactLecturer);

        void UpdateContactLecturerValueRepo(ContactLecturer contactLecturer);

        ContactLecturer GetValueContactLecturerById(int id);
    }
}