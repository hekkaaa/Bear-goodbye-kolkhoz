using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class TrainingService : ITrainingService
    {
        private ITrainingRepository _repository;
        private IMapper _mapper;

        public TrainingService(ITrainingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public void UpdateTraining(int id, TrainingModel trainingModel)
        {
            var training = _repository.GetTrainingById(id);

            if (training == null)
                throw new Exception("Такого тренинга не найдено!");

            var trainingEntity = _mapper.Map<Training>(trainingModel);
            _repository.UpdateTraining(trainingEntity);
        }

        public TrainingModel GetTrainingModelById(int id)
        {
            var trainingEntity = _repository.GetTrainingById(id);
            return _mapper.Map<TrainingModel>(trainingEntity);
        }

        public List<TrainingModel> GetTrainingModelsAll()
        {
            var trainingEntityList = _repository.GetTrainings();
            return _mapper.Map<List<TrainingModel>>(trainingEntityList);
        }

        public List<TrainingModel> GetTrainingModelByTopic(TopicModel topicModel)
        {
            var trainingEntityList = _repository.GetTrainingsByTopic(_mapper.Map<Topic>(topicModel));
            return _mapper.Map<List<TrainingModel>>(trainingEntityList);
        }

        public void AddTraining(TrainingModel trainingModel)
        {
            var trainingEntity = _mapper.Map<Training>(trainingModel);

            _repository.AddTraining(trainingEntity);
        }

        public void DeleteTraining(TrainingModel trainingModel)
        {
            if (_repository.GetTrainingById(trainingModel.Id) == null)
                throw new RepositoryException("Такого тренинга не найдено. Удаление невозможно.");

            _repository.DeleteTraining(trainingModel.Id);
        }
    }
}
