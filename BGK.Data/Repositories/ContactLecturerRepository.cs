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

        public void AddContact(ContactLecturer contact)
        {
            _context.ContactLecturer.Add(contact);
            _context.SaveChanges();
        }

        public ContactLecturer GetValueContactLecturerById(int id) =>
            _context.ContactLecturer.Find(id);


        public void UpdateContactLecturerValueRepo(ContactLecturer contactLecturer)
        {
            var entity = GetValueContactLecturerById(contactLecturer.Id);

            entity.Value = contactLecturer.Value;

            _context.SaveChanges();
        }


    }
}
