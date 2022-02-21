using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
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

        public Lecturer Login(string email)
        {
            Lecturer lecturer = _context.Lecturer
                .Where(l => l.Email == email)
                .FirstOrDefault();

            return lecturer;
        }

        public Lecturer GetLecturerById(int id) =>
            _context.Lecturer.FirstOrDefault(L => L.Id == id);

        public List<Lecturer> GetLecturers() =>
            _context.Lecturer.Where(t => !t.IsDeleted).ToList();

        public void AddLecturer(Lecturer model)
        {
            model.Role = Role.Lecturer;
            _context.Lecturer.Add(model);
            _context.SaveChanges();
        }

        public void UpdateLecturer(Lecturer lecturer, Lecturer model)
        {

            lecturer.BirthDay = model.BirthDay;
            lecturer.Name = model.Name;
            lecturer.LastName = model.LastName;
            lecturer.Gender = model.Gender;

            _context.SaveChanges();
        }

        public void AddTraining(Lecturer lecturer, Training training)
        {
            lecturer.Trainings.Add(training);

            _context.SaveChanges();
        }

        public void DeleteTraining(int lecturerId, Training training)
        {
            var entity = GetLecturerById(lecturerId);
            entity.Trainings.Remove(training);
            _context.SaveChanges();
        }

        public void ChangeDeleteStatusById(Lecturer lecturer, bool isDeleted)
        {
            lecturer.IsDeleted = isDeleted;
            _context.SaveChanges();
        }

    }
}