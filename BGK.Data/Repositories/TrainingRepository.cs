using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {

        private ApplicationContext _context;

        public TrainingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Training GetTrainingById(int id) =>
           _context.Training.FirstOrDefault(t => t.Id == id);

        public List<Training> GetTrainings() =>
            _context.Training.Where(t => !t.IsDeleted).ToList();


        public void UpdateTraining(Training training)
        {
            var oldTraining = GetTrainingById(training.Id);
            oldTraining.MembersCount = training.MembersCount;
            oldTraining.Name = training.Name;
            oldTraining.Price = training.Price;
            oldTraining.Topic = training.Topic;
            oldTraining.Duration = training.Duration;
            oldTraining.Description = training.Description;
            _context.SaveChanges();
        }

        public void AddTraining(Training training)
        {
            _context.Training.Add(training);
            _context.SaveChanges();
        }

        public void DeleteTraining(int id)
        {
            var training = GetTrainingById(id);
            training.IsDeleted = false;
            _context.SaveChanges();
        }

    }
}
