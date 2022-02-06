using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private ApplicationContext _context;

        public LecturerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Lecturer GetLecturerById(int id)
        {
            return _context.Lecturer.Find(id);
        }

        public List<Lecturer> GetLecturers()
        {
            return _context.Lecturer.Where(t => !t.IsDeleted).ToList();
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

            _context.SaveChanges();
        }

        public void AddTraining(int lecturerId, int trainingId)
        {
            var entity = GetLecturerById(lecturerId);
            var trainings = _context.Training.FirstOrDefault(trainig => trainig.Id == trainingId);
            if (trainings is not null)
            {
                entity.Trainings.Add(trainings);
            }

            _context.SaveChanges();
        }

        public void DeleteTraining(int lecturerId, Training model)
        {
            var entity = GetLecturerById(lecturerId);
            Training res = entity.Trainings.FirstOrDefault(trainig => trainig.Id == model.Id);

            if (res is not null)
            {
                entity.Trainings.Remove(res);
                _context.SaveChanges();
            }
        }

        public void DeleteLecturerById(int id)
        {
            var entity = GetLecturerById(id);
            entity.IsDeleted = true;
            _context.SaveChanges();
        }

        public void RecoverLecturerById(int id)
        {
            var entity = _context.Lecturer.Find(id);
            entity.IsDeleted = false;
            _context.SaveChanges();
        }
    }
}
