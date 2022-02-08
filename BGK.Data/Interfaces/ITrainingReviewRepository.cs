using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ITrainingReviewRepository
    {
        void AddTrainingReview(TrainingReview trainingReview);
        void DeleteTrainingReview(int id);
        TrainingReview GetTrainingReviewById(int id);
        List<TrainingReview> GetTrainingReviews();
        void UpdateTrainingReview(TrainingReview trainingReview);
    }
}