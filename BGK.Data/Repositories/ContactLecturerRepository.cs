using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class ContactLecturerRepository : IContactLecturerRepository
    {
        private ApplicationContext _context;

        public ContactLecturerRepository(ApplicationContext context)
        {
            _context = context;
        }


        public void AddValue(ContactLecturer сontactLecturer)
        {
            _context.ContactLecturer.Add(сontactLecturer);

            _context.SaveChanges();
        }
    }
}
