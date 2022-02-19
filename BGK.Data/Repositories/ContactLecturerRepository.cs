using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class ContactLecturerRepository : IContactLecturerRepository
    {
        private ApplicationContext _context;

        public ContactLecturerRepository(ApplicationContext context)
        {
            _context = context;
        }


        public ContactLecturer GetValueContactLecturerById(int id) =>
            _context.ContactLecturer.Find(id);

        public void AddContactLecturerValueRepo(ContactLecturer сontactLecturer)
        {

            var entity = GetValueContactLecturerById(сontactLecturer.Id);

            entity.Value = сontactLecturer.Value;
            
            _context.SaveChanges();
   
        }

        public void UpdateContactLecturerValueRepo(ContactLecturer contactLecturer)
        {
            var entity = GetValueContactLecturerById(contactLecturer.Id);

            entity.Value = contactLecturer.Value;
            
            _context.SaveChanges();
        }


    }
}
