using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Interfaces
{
    public interface ITrainingRepository
    {
        void AddTraining(Training training);
        void DeleteTraining(int id);
        Training GetTrainingById(int id);
        List<Training> GetTrainings();
        void UpdateTraining(Training training);
    }
}