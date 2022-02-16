using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface ITrainingService
    {
        void AddTraining(TrainingModel trainingModel);
        void DeleteTraining(TrainingModel trainingModel);
        TrainingModel GetTrainingModelById(int id);
        List<TrainingModel> GetTrainingModels();
        List<TrainingModel> GetTrainingModelByTopic(TopicModel topicModel);
        void UpdateTraining(int id, TrainingModel trainingModel);
    }
}