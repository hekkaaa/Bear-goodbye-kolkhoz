using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface ITrainingService
    {
        int AddTraining(TrainingModel trainingModel);
        void DeleteTraining(TrainingModel trainingModel);
        TrainingModel GetTrainingModelById(int id);
        List<TrainingModel> GetTrainingModels();
        List<TrainingModel> GetTrainingModelByTopic(TopicModel topicModel);
        void UpdateTraining(int id, TrainingModel trainingModel);
    }
}