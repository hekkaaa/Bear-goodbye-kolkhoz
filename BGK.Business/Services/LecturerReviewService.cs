using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class LecturerReviewService : ILecturerReviewService
    {
        private readonly IMapper _mapper;
        private readonly ILecturerReviewRepository _lecturerReviewRepo;
        public LecturerReviewService(IMapper mapper, ILecturerReviewRepository lecturerReviewRepo)
        {
            _mapper = mapper;
            _lecturerReviewRepo = lecturerReviewRepo;
        }

        public LecturerReviewModel GetLecturerReviewModelById(int id)
        {
            var review = _lecturerReviewRepo.GetLecturerReviewById(id);
            if (review is null)
            {
                throw new NotFoundException($"Нет отзыва c id = {id}");
            };

            return _mapper.Map<LecturerReviewModel>(review);
        }

        public List<LecturerReviewModel> GetLecturerReviews()
        {
            var reviews = _lecturerReviewRepo.GetLecturerReviews();
            return _mapper.Map<List<LecturerReviewModel>>(reviews);
        }

        public List<LecturerReviewModel> GetLecturerReviewsByLecturerId(int lecturerId)
        {
            var reviews = _lecturerReviewRepo.GetLecturerReviewsByLecturerId(lecturerId);
            return _mapper.Map<List<LecturerReviewModel>>(reviews);
        }

        public void AddLecturerReview(LecturerReviewModel model)
        {
            var entity = _mapper.Map<LecturerReview>(model);
            _lecturerReviewRepo.AddLecturerReview(entity);
        }

        public void DeleteLecturerReviewById(int id)
        {
            var review = _lecturerReviewRepo.GetLecturerReviewById(id);

            if (review is null)
            {
                throw new NotFoundException($"Нет отзыва c id = {id}");
            };

            _lecturerReviewRepo.ChangeIsDeleted(review, true);
        }

        public void RecoverLecturerReviewById(int id)
        {
            var review = _lecturerReviewRepo.GetLecturerReviewById(id);

            if (review is null)
            {
                throw new NotFoundException($"Нет отзыва c id = {id}");
            };

            _lecturerReviewRepo.ChangeIsDeleted(review, false);
        }
    }
}
