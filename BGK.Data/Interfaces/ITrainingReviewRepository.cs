using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ITrainingReviewRepository
    {
        void AddTrainingReview(TrainingReview trainingReview);
        void DeleteTrainingReview(int id);
        List<TrainingReview> GetTrainingReviews();
        TrainingReview GetTrainingReviewById(int id);
        void UpdateTrainingReview(TrainingReview trainingReview);
    }
}