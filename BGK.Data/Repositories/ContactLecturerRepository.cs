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
            _context.ContactLecturer.FirstOrDefault(cl => cl.Id == id);


        public void UpdateContact(ContactLecturer contactLecturer, ContactLecturer contact)
        {
            contactLecturer.Value = contact.Value;
            contactLecturer.ContactType = contact.ContactType;
            _context.SaveChanges();
        }
    }
}
