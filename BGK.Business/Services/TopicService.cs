﻿using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;
using AutoMapper;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public class TopicService
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
                throw new Exception("Нет такой темы");
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
                throw new Exception("Ты передал в меня null");
            }

            var topic = _mapper.Map<Topic>(model);
            _topicRepo.AddTopic(topic);
        }

        public void UpdateTopic(TopicModel model)
        {
            var topic = _mapper.Map<Topic>(model);
            _topicRepo.UpdateTopic(topic);
        }

        public void DeleteTopicById(int id)
        {
            if (_topicRepo.GetTopicById(id) is null)
            {
                throw new Exception("Нет такой темы");
            }

            _topicRepo.ChangeDeleteStatusById(id, true);
        }

        public void RecoverTopicById(int id)
        {
            if (_topicRepo.GetTopicById(id) is null)
            {
                throw new Exception("Нет такой темы");
            }

            _topicRepo.ChangeDeleteStatusById(id, false);
        }
    }
}
