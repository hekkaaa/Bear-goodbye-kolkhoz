using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ILecturerReviewRepository
    {
        void AddLecturerReview(LecturerReview model);
        void ChangeIsDeleted(LecturerReview review, bool isDeleted);
        LecturerReview GetLecturerReviewById(int id);
        List<LecturerReview> GetLecturerReviews();
        List<LecturerReview> GetLecturerReviewsByLecturerId(int id);
    }
}