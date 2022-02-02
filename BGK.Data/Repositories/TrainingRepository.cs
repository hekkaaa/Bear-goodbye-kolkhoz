using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class TrainingRepository
    {

        private ApplicationContext _applicationContext;

        public TrainingRepository()
        {
            _applicationContext = Storage.GetStorage();
        }

        public Training GetTrainingById(int id) =>
           _applicationContext.Training.FirstOrDefault(t => t.Id == id);

        public List<Training> GetTrainingsAll() =>
            _applicationContext.Training.ToList<Training>();

        public List<Training> GetDeletedTrainings =>
            _applicationContext.Training.Where(t => !t.IsDeleted).ToList<Training>();

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
