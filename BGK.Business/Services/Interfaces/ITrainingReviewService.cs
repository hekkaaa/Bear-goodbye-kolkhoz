using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface ITrainingReviewService
    {
        int AddTrainingReview(TrainingReviewModel trainingReviewModel);
        void DeleteTrainingReview(int id);
        TrainingReviewModel GetTrainingReviewModelById(int id);
        List<TrainingReviewModel> GetTrainingReviewModels();
        void UpdateTrainingReview(int id, TrainingReviewModel trainingReviewModel);
    }
}