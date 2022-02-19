using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface ITrainingService
    {
        int AddTraining(TrainingModel trainingModel);
        void DeleteTraining(int id);
        TrainingModel GetTrainingModelById(int id);
        List<TrainingModel> GetTrainingModels();
        List<TrainingModel> GetTrainingModelByTopic(TopicModel topicModel);
        void UpdateTraining(int id, TrainingModel trainingModel);
        void AddTopicToTraining(int id, int topicId);
        void AddReviewToTraining(int id, TrainingReviewModel trainingReview);
    }
}