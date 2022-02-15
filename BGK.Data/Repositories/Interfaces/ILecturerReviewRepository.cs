using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ILecturerReviewRepository
    {
        void AddLecturerReview(LecturerReview model);
        void DeleteLecturerReviewById(int id);
        LecturerReview GetLecturerReviewById(int id);
        List<LecturerReview> GetLecturerReviews();
        List<LecturerReview> GetLecturerReviewsByLecturerId(int id);
    }
}