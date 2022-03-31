using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ITrainingReviewRepository
    {
        int AddTrainingReview(TrainingReview trainingReview);
        bool DeleteTrainingReview(TrainingReview trainingReview, bool isDeleted);
        List<TrainingReview> GetTrainingReviews();
        TrainingReview GetTrainingReviewById(int id);
        void UpdateTrainingReview(TrainingReview trainingReview);
        List<TrainingReview> GetReviewByTrainingId(int trainingId);
    }
}