using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class TrainingReviewService
    {
        private TrainingReviewRepository _repository;

        private IMapper _mapper;

        public TrainingReviewService(IMapper mapper)
        {
            _repository = new TrainingReviewRepository();
            _mapper = mapper;
         }

        public void UpdateTrainingReview(int id, TrainingReviewModel trainingReviewModel)
        {
            var training = _repository.GetTrainingReviewById(id);

            if (training == null)
                throw new Exception("Такого обзора на тренинг не найдено!");

            
            _repository.UpdateTrainingReview(_mapper.Map<TrainingReview>(trainingReviewModel));
        }

        public TrainingReviewModel GetTrainingReviewModelById(TrainingReviewModel trainingReviewModel)
        {
            var trainingReviewEntity = _repository.GetTrainingReviewById(trainingReviewModel.Id);
            return _mapper.Map<TrainingReviewModel>(trainingReviewEntity);
        }

        public List<TrainingReviewModel> GetTrainingReviewModelsAll()
        {
            var trainingReviewEntityList = _repository.GetTrainingReviews();
            return _mapper.Map<List<TrainingReviewModel>>(trainingReviewEntityList);
        }

        public void AddTrainingReview(TrainingReviewModel trainingReviewModel)
        {
            var trainingReviewEntity = _mapper.Map<TrainingReview>(trainingReviewModel);
            _repository.AddTrainingReview(trainingReviewEntity);
        }

        public void DeleteTrainingReview(TrainingReviewModel trainingReviewModel)
        {
            _repository.DeleteTrainingReview(trainingReviewModel.Id);
        }
    }
}