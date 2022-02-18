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

        public void AddValue(ContactLecturer сontactLecturer)
        {
            _context.ContactLecturer.Add(сontactLecturer);

            _context.SaveChanges();
        }

        public void UpdateValue(ContactLecturer contactLecturer)
        {
            var entity = GetValueContactLecturerById(contactLecturer.Id);

            entity.Value = contactLecturer.Value;
            

            _context.ContactLecturer.Update(entity);

            _context.SaveChanges();
        }


    }
}
