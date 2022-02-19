using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface ILecturerReviewService
    {
        void AddLecturerReview(LecturerReviewModel model);
        void DeleteLecturerReviewById(int id);
        LecturerReviewModel GetLecturerReviewModelById(int id);
        List<LecturerReviewModel> GetLecturerReviews();
        List<LecturerReviewModel> GetLecturerReviewsByLecturerId(int lecturerId);
        void RecoverLecturerReviewById(int id);
    }
}