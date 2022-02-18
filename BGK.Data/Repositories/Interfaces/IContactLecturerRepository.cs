using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IContactLecturerRepository
    {
        void AddValue(ContactLecturer сontactLecturer);

        void UpdateValue(ContactLecturer contactLecturer);

        ContactLecturer GetValueContactLecturerById(int id);
    }
}