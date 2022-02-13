using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface ITopicRepository
    {
        void AddTopic(Topic model);
        void ChangeDeleteStatusById(Topic topic, bool IsDeleted);
        List<Topic> GetTopics();
        Topic GetTopicById(int id);
        void UpdateTopic(Topic model);
    }
}