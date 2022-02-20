using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class TopicService : ITopicService
    {
        private readonly IMapper _mapper;
        private readonly ITopicRepository _topicRepo;

        public TopicService(IMapper mapper, ITopicRepository topicRepository)
        {
            _mapper = mapper;
            _topicRepo = topicRepository;
        }

        public TopicModel GetTopicById(int id)
        {
            var topic = _topicRepo.GetTopicById(id);

            if (topic is null)
            {
                throw new NotFoundException($"Нет темы c id = {id}");
            }

            return _mapper.Map<TopicModel>(topic);
        }

        public List<TopicModel> GetTopics()
        {
            var topics = _topicRepo.GetTopics();
            return _mapper.Map<List<TopicModel>>(topics);
        }

        public void AddTopic(TopicModel model)
        {
            if (model is null)
            {
                throw new Exception($"Передана не верная модель: {model}");
            }

            var topic = _mapper.Map<Topic>(model);
            _topicRepo.AddTopic(topic);
        }

        public void UpdateTopic(TopicModel model, int id)
        {
            var topic = _mapper.Map<Topic>(model);
            _topicRepo.UpdateTopic(topic, id);
        }

        public void DeleteTopic(TopicModel model)
        {
            var topic = _topicRepo.GetTopicById(model.Id);
            if (topic is null)
            {
                throw new NotFoundException($"Нет темы c id = {model.Id}");
            }

            _topicRepo.ChangeDeleteStatus(topic, true);
        }

        public void RecoverTopic(TopicModel model)
        {
            var topic = _topicRepo.GetTopicById(model.Id);
            if (topic is null)
            {
                throw new NotFoundException($"Нет темы c id = {model.Id}");
            }

            _topicRepo.ChangeDeleteStatus(topic, false);
        }
    }
}
