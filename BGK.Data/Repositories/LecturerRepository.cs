using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class LecturerRepository : ILecturerRepository
    {
        private ApplicationContext _context;

        public LecturerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Lecturer GetLecturerById(int id) =>
            _context.Lecturer.FirstOrDefault(L => L.Id == id);

        public Lecturer GetLecturerByIdAndIncludeTraning(int id) =>
            _context.Lecturer.Include(x => x.Trainings).FirstOrDefault(L => L.Id == id);

        public List<Lecturer> GetLecturers() =>
            _context.Lecturer.Where(l => !l.IsDeleted).ToList();

        public List<Lecturer> GetLecturerByTrainingId(int trainingId)
        {
            return _context.Lecturer
                .Where(l => !l.IsDeleted)
                .Where(l => l.Trainings.FirstOrDefault(t => t.Id == trainingId) != null)
                .Include(l => l.Events)
                .ToList();
        }

        public int AddLecturer(Lecturer model)
        {
            model.Role = Role.Lecturer;
            _context.Lecturer.Add(model);
            _context.SaveChanges();
            return model.Id;
        }

        public void UpdateLecturer(Lecturer lecturer, Lecturer updateLecturer)
        {
            lecturer.BirthDay = updateLecturer.BirthDay;
            lecturer.Name = updateLecturer.Name;
            lecturer.LastName = updateLecturer.LastName;
            lecturer.Gender = updateLecturer.Gender;

            _context.SaveChanges();
        }

        public bool UpdateLecturer(Lecturer lecturer, bool isDeleted)
        {
            var oldLecturer = GetLecturerById(lecturer.Id);
            oldLecturer.IsDeleted = isDeleted;
            _context.SaveChanges();
            return true;
        }

        public bool AddTraining(Lecturer lecturer, Training training)
        {
            lecturer.Trainings.Add(training);

            _context.SaveChanges();

            return true;
        }

        public void DeleteTraining(Lecturer lecturer, Training training)
        {
            lecturer.Trainings.Remove(training);
            _context.SaveChanges();
        }

        public int GetEventsCount(Lecturer lecturer)
        {
            return _context.Event.Where(e => e.Lecturer.Id == lecturer.Id).ToList().Count;
        }


    }
}