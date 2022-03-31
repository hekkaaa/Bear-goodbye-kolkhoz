using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ITrainingReviewRepository
    {
        int AddTrainingReview(TrainingReview trainingReview);
        void DeleteTrainingReview(TrainingReview trainingReview);
        List<TrainingReview> GetTrainingReviews();
        TrainingReview GetTrainingReviewById(int id);
        void UpdateTrainingReview(TrainingReview trainingReview);
        List<TrainingReview> GetReviewByTrainingId(int trainingId);
    }
}