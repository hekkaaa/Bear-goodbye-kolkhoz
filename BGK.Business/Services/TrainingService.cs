using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Interfaces;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class TrainingService : ITrainingService
    {
        private ITrainingRepository _repository;
        private IClientRepository _clientRepository;
        private IMapper _mapper;

        public TrainingService(ITrainingRepository repository, IMapper mapper, IClientRepository clientRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public void UpdateTraining(int id, TrainingModel trainingModel)
        {
            var training = _repository.GetTrainingById(id);

            if (training == null)
                throw new BusinessException("Такого тренинга не найдено!");

            var trainingEntity = _mapper.Map<Training>(trainingModel);
            trainingEntity.Id = id;
            _repository.UpdateTraining(trainingEntity);
        }

        public TrainingModel GetTrainingModelById(int id)
        {
            var trainingEntity = _repository.GetTrainingById(id);
            if (trainingEntity == null)
                throw new BusinessException("Такого тренинга не найдено!");
            return _mapper.Map<TrainingModel>(trainingEntity);
        }

        public List<TrainingModel> GetTrainingModels()
        {
            var trainingEntityList = _repository.GetTrainings();
            return _mapper.Map<List<TrainingModel>>(trainingEntityList);
        }

        public List<TrainingModel> GetTrainingModelByTopic(TopicModel topicModel)
        {
            var trainingEntityList = _repository.GetTrainingsByTopic((_mapper.Map<Topic>(topicModel)));
            return _mapper.Map<List<TrainingModel>>(trainingEntityList);
        }

        public int AddTraining(TrainingModel trainingModel)
        {
            var trainingEntity = _mapper.Map<Training>(trainingModel);
            return _repository.AddTraining(trainingEntity);
        }

        public void DeleteTraining(int id)
        {
            var trainingEntity = _repository.GetTrainingById(id);
            if (trainingEntity == null)
                throw new BusinessException("Такого тренинга не найдено!");
            _repository.UpdateTraining(_mapper.Map<Training>(trainingEntity), true);
        }

        public void RestoreTraining(TrainingModel trainingModel)
        {
            var trainingEntity = _repository.GetTrainingById(trainingModel.Id);
            if (trainingEntity == null)
                throw new BusinessException("Такого тренинга не найдено!");
            _repository.UpdateTraining(_mapper.Map<Training>(trainingModel), false);
        }

        public void AddTopicToTraining(int id, int topicId)
        {
            _repository.AddTopicToTraining(id, topicId);
        }

        public void AddReviewToTraining(int trainingId, TrainingReviewModel trainingReview)
        {
            var training = _repository.GetTrainingById(trainingId);
            if (training == null)
                throw new BusinessException("Такого тренинга не найдено!");

            _repository.AddReviewToTraining(trainingId, _mapper.Map<TrainingReview>(trainingReview));
        }

    }
}
