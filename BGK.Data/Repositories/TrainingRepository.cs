using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class TrainingRepository
    {

        private ApplicationContext _applicationContext;

        public TrainingRepository()
        {
            _applicationContext = Storage.GetInstance();
        }

        public Training GetTrainingById(int id) =>
           _applicationContext.Training.FirstOrDefault(t => t.Id == id);

        public List<Training> GetTrainings() =>
            _applicationContext.Training.Where(t => !t.IsDeleted).ToList();


        public void UpdateTraining(Training training)
        {
            var oldTraining = GetTrainingById(training.Id);
            oldTraining.MembersCount = training.MembersCount;
            oldTraining.Name = training.Name;
            oldTraining.Price = training.Price;
            oldTraining.Topic = training.Topic;
            oldTraining.Duration = training.Duration;
            oldTraining.Description = training.Description;
            _applicationContext.SaveChanges();
        }

        public void AddTraining(Training training)
        {
            _applicationContext.Training.Add(training);
            _applicationContext.SaveChanges();
        }

        public void DeleteTraining(int id)
        {
            var training = GetTrainingById(id);
            training.IsDeleted = false;
            _applicationContext.SaveChanges();
        }

    }
}
