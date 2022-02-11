﻿using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {

        private ApplicationContext _applicationContext;

        public TrainingRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Training GetTrainingById(int id) =>
           _applicationContext.Training.FirstOrDefault(t => t.Id == id);

        public List<Training> GetTrainings() =>
            _applicationContext.Training.Where(t => !t.IsDeleted).ToList();

        public List<Training> GetTrainingsByTopic(Topic topic) =>
            _applicationContext.Training.Where(t => t.Topics.Any(t => t.Name == topic.Name)).ToList();

        //_applicationContext.Training.Where(t => t.Topic == topic && !t.IsDeleted).ToList();

        public void UpdateTraining(Training training)
        {
            var oldTraining = GetTrainingById(training.Id);

            oldTraining.MembersCount = training.MembersCount;
            oldTraining.Name = training.Name;
            oldTraining.Price = training.Price;
            oldTraining.Topics = training.Topics;
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



            training.IsDeleted = true;
            _applicationContext.SaveChanges();
        }

    }
}
