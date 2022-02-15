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


        public void AddValue(ContactLecturer сontactLecturer)
        {
            _context.ContactLecturer.Add(сontactLecturer);

            _context.SaveChanges();
        }
    }
}
