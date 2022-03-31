using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface ITrainingReviewService
    {
        int AddTrainingReview(TrainingReviewModel trainingReviewModel);
        bool DeleteTrainingReview(int id);
        TrainingReviewModel GetTrainingReviewModelById(int id);
        List<TrainingReviewModel> GetTrainingReviewModels();
        void UpdateTrainingReview(int id, TrainingReviewModel trainingReviewModel);
        List<TrainingReviewModel> GetReviewsByTrainingId(int trainingId);
    }
}