using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class LecturerRepository
    {
        private ApplicationContext _context = Storage.GetInstance();

        public Lecturer GetLecturerById(int id)
        {
            return _context.Lecturer.Find(id);
        }

        public List<Lecturer> GetLecturers()
        {
            return _context.Lecturer.ToList();
        }

        public void AddLecturer(Lecturer model)
        {
            _context.Lecturer.Add(model);
            _context.SaveChanges();
        }

        public void UpdateLecturer(Lecturer model)
        {
            var entity = GetLecturerById(model.Id);
            entity.BirthDay = model.BirthDay;
            entity.Name = model.Name;
            entity.LastName = model.LastName;
            entity.Gender = model.Gender;
            entity.IsDeleted = model.IsDeleted;
            //
            _context.SaveChanges();
        }

        public void DeleteLecturerById(int id)
        {
            var entity = GetLecturerById(id);
            entity.IsDeleted = true;
            _context.SaveChanges();
        }


    }
}
