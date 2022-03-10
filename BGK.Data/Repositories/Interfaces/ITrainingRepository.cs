using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ITrainingRepository
    {
        int AddTraining(Training training);
        Training GetTrainingById(int id);
        List<Training> GetTrainings();
        List<Training> GetTrainingsByTopic(Topic topic);
        void UpdateTraining(Training training);
        bool UpdateTraining(Training training, bool IsDeleted);

    }
}