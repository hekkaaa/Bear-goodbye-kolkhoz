using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class TrainingReviewService : ITrainingReviewService
    {
        private ITrainingReviewRepository _repository;

        public TrainingReviewService(ITrainingReviewRepository repository)
        {
            _repository = repository;
        }

        public void UpdateTrainingReview(int id, TrainingReviewModel trainingReviewModel)
        {
            var training = _repository.GetTrainingReviewById(id);

            if (training == null)
                throw new Exception("Такого обзора на тренинг не найдено!");

            var trainingReviewEntity = CustomMapper.GetInstance().Map<TrainingReview>(trainingReviewModel);
            _repository.UpdateTrainingReview(trainingReviewEntity);
        }

        public TrainingReviewModel GetTrainingReviewModelById(int id)
        {
            var trainingReviewEntity = _repository.GetTrainingReviewById(id);
            return CustomMapper.GetInstance().Map<TrainingReviewModel>(trainingReviewEntity);
        }

        public List<TrainingReviewModel> GetTrainingReviewModels()
        {
            var trainingReviewEntityList = _repository.GetTrainingReviews();
            return CustomMapper.GetInstance().Map<List<TrainingReviewModel>>(trainingReviewEntityList);
        }

        public void AddTrainingReview(TrainingReviewModel trainingReviewModel)
        {
            var trainingReviewEntity = CustomMapper.GetInstance().Map<TrainingReview>(trainingReviewModel);
            _repository.AddTrainingReview(trainingReviewEntity);
        }

        public void DeleteTrainingReview(TrainingReviewModel trainingReviewModel)
        {
            _repository.DeleteTrainingReview(trainingReviewModel.Id);
        }
    }
}