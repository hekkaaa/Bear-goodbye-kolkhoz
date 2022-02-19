using BearGoodbyeKolkhozProject.Data.ConnectDb;
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
            _applicationContext.Training.Where(t => t.Topics.Any(t => t.Id == topic.Id)).ToList();

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
        public void UpdateTraining(Training training, bool isDeleted)
        {
            var oldTraining = GetTrainingById(training.Id);
            oldTraining.IsDeleted = isDeleted;
            _applicationContext.SaveChanges();
        }

        public int AddTraining(Training training)
        {
            _applicationContext.Training.Add(training);
            _applicationContext.SaveChanges();
            return training.Id;
        }

        public void AddTopicToTraining(int id, int topicId)
        {
            var training = GetTrainingById(id);
            var topic = _applicationContext.Topic.FirstOrDefault(t => t.Id == topicId);

            if (training.Topics == null)
            {
                training.Topics = new List<Topic>();
            }

            training.Topics.Add(topic);
            _applicationContext.SaveChanges();
        }

        public void AddReviewToTraining(int id, TrainingReview trainingReview)
        {
            var training = GetTrainingById(id);
            var client = _applicationContext.Client.FirstOrDefault(c => c.Id == id);


            if (training.TrainingReviews == null)
            {
                training.TrainingReviews = new List<TrainingReview>();
            }
            trainingReview.Training = training;
            trainingReview.Client = client;

            _applicationContext.TrainingReview.Add(trainingReview);
            _applicationContext.SaveChanges();
        }

    }
}
