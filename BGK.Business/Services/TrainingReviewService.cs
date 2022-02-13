﻿using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class TrainingReviewService : ITrainingReviewService
    {
        private ITrainingReviewRepository _repository;
        private IMapper _mapper;


        public TrainingReviewService(ITrainingReviewRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void UpdateTrainingReview(int id, TrainingReviewModel trainingReviewModel)
        {
            var training = _repository.GetTrainingReviewById(id);

            if (training == null)
                throw new BusinessException("Такого обзора на тренинг не найдено!");

            var trainingReviewEntity = _mapper.Map<TrainingReview>(trainingReviewModel);
            _repository.UpdateTrainingReview(trainingReviewEntity);
        }

        public TrainingReviewModel GetTrainingReviewModelById(int trainingReviewId)
        {
            var trainingReviewEntity = _repository.GetTrainingReviewById(trainingReviewId);

            if (trainingReviewEntity == null)
                throw new BusinessException("Такого обзора на тренинг не найдено!");

            return _mapper.Map<TrainingReviewModel>(trainingReviewEntity);
        }

        public List<TrainingReviewModel> GetTrainingReviewModels()
        {
            var trainingReviewEntityList = _repository.GetTrainingReviews();

            if (trainingReviewEntityList.Count == 0)
                throw new BusinessException("Обзоров на тренинги ещё не написано");

            return _mapper.Map<List<TrainingReviewModel>>(trainingReviewEntityList);
        }

        public void AddTrainingReview(TrainingReviewModel trainingReviewModel)
        {
            var trainingReviewEntity = _mapper.Map<TrainingReview>(trainingReviewModel);
            _repository.AddTrainingReview(trainingReviewEntity);
        }

        public void DeleteTrainingReview(TrainingReviewModel trainingReviewModel)
        {
            var trainingReviewEntity = _repository.GetTrainingReviewById(trainingReviewModel.Id);

            if (trainingReviewEntity == null)
                throw new BusinessException("Такого обзора на тренинг не найдено!");

            _repository.DeleteTrainingReview(trainingReviewModel.Id);
        }
    }
}