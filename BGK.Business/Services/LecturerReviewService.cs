using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class LecturerReviewService
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
            var entity = _lecturerReviewRepo.GetLecturerReviewById(id);
            if (entity is null)
            {
                throw new Exception("Нет такого отзыва");
            };

            return _mapper.Map<LecturerReviewModel>(entity);
        }

        public List<LecturerReviewModel> GetLecturerReviews()
        {
            var reviews = _lecturerReviewRepo.GetLecturerReviews();
            return _mapper.Map<List<LecturerReviewModel>>(reviews);
        }
    }
}
