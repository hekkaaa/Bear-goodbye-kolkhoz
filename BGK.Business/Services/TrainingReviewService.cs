using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class TrainingReviewService
    {
        private TrainingReviewRepository _repository;

        public TrainingReviewService()
        {
            _repository = new TrainingReviewRepository();
        }

        public void UpdateTrainingReview(int id, TrainingReviewModel trainingReviewModel)
        {
            var training = _repository.GetTrainingReviewById(id);

            if (training == null)
                throw new Exception("Такого обзора на тренинг не найдено!");

            var trainingReviewEntity = CustomMapper.GetInstance().Map<TrainingReview>(trainingReviewModel);
            _repository.UpdateTrainingReview(trainingReviewEntity);
        }

        public TrainingReviewModel GetTrainingReviewModelById(TrainingReviewModel trainingReviewModel)
        {
            var trainingReviewEntity = _repository.GetTrainingReviewById(trainingReviewModel.Id);
            return CustomMapper.GetInstance().Map<TrainingReviewModel>(trainingReviewEntity);
        }

        public List<TrainingReviewModel> GetTrainingReviewModelsAll()
        {
            var trainingReviewEntityList = _repository.GetTrainingReviewsAll();
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