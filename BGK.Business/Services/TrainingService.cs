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
        private IClientRepository _clientRepository;
        private ITrainingReviewRepository _trainingReviewRepository;
        private ITopicRepository _topicRepository;
        private IMapper _mapper;
        private EmailSender _emailSender;

        public TrainingService(ITrainingRepository repository, IMapper mapper, IClientRepository clientRepository, ITrainingReviewRepository trainingReviewRepository, ITopicRepository topicRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _trainingReviewRepository = trainingReviewRepository;
            _topicRepository = topicRepository;
            _clientRepository = clientRepository;
            _emailSender = new EmailSender();
        }

        public void UpdateTraining(int id, TrainingModel trainingModel)
        {
            var training = _repository.GetTrainingById(id);

            if (training == null)
                throw new NotFoundException("Такого тренинга не найдено!");

            var trainingEntity = _mapper.Map<Training>(trainingModel);
            trainingEntity.Id = id;
            _repository.UpdateTraining(trainingEntity);
        }

        public TrainingModel GetTrainingModelById(int id)
        {
            var trainingEntity = _repository.GetTrainingById(id);
            if (trainingEntity == null)
                throw new NotFoundException("Такого тренинга не найдено!");
            return _mapper.Map<TrainingModel>(trainingEntity);
        }

        public List<TrainingModel> GetTrainingModels()
        {
            var trainingEntityList = _repository.GetTrainings();
            return _mapper.Map<List<TrainingModel>>(trainingEntityList);
        }

        public List<TrainingModel> GetTrainingModelByTopic(TopicModel topicModel)
        {
            var topic = _topicRepository.GetTopicById(topicModel.Id);
            if (topic == null)
                throw new NotFoundException("Такого интереса не существует");

            var trainingEntityList = _repository.GetTrainingsByTopic(topic);
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
                throw new NotFoundException("Такого тренинга не найдено!");
            _repository.UpdateTraining(_mapper.Map<Training>(trainingEntity), true);
        }

        public void RestoreTraining(TrainingModel trainingModel)
        {
            var trainingEntity = _repository.GetTrainingById(trainingModel.Id);
            if (trainingEntity == null)
                throw new NotFoundException("Такого тренинга не найдено!");
            _repository.UpdateTraining(_mapper.Map<Training>(trainingModel), false);
        }

        public void AddTopicToTraining(int id, int topicId)
        {
            var topic = _topicRepository.GetTopicById(topicId);
            var training = _repository.GetTrainingById(id);

            training.Topics.Add(topic);

            _repository.UpdateTraining(training);

        }

        public void AddReviewToTraining(int trainingId, int clientId, TrainingReviewModel trainingReview)
        {
            var training = _repository.GetTrainingById(trainingId);

            if (training == null)
                throw new NotFoundException("Такого тренинга не найдено!");

            var client = _clientRepository.GetClientById(clientId);

            if (client == null)
                throw new NotFoundException("Такого клиента нет!");

            var trainingReviewEntity = _mapper.Map<TrainingReview>(trainingReview);
            trainingReviewEntity.Client = client;

            if (training.TrainingReviews is null)
            {
                training.TrainingReviews = new List<TrainingReview>();
            }

            training.TrainingReviews.Add(trainingReviewEntity);

            _repository.UpdateTraining(training);
        }


        //удолить после проверки
        public void SendEmail()
        {
            EventModel em = new EventModel { StartDate = "20.05.01" };
            _emailSender.SendEmail("ff", "ff", em);
        }
    }
}