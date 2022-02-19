using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface ITopicService
    {
        void AddTopic(TopicModel model);
        void DeleteTopic(TopicModel model);
        TopicModel GetTopicById(int id);
        List<TopicModel> GetTopics();
        void RecoverTopic(TopicModel model);
        void UpdateTopic(TopicModel model, int id);
    }
}