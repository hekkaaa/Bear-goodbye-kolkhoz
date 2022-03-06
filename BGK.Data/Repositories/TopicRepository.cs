using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private ApplicationContext _context;

        public TopicRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Topic GetTopicById(int id) =>
            _context.Topic.Where(t => !t.IsDeleted).FirstOrDefault(t => t.Id == id);

        public List<Topic> GetTopics() =>
            _context.Topic.Where(t => !t.IsDeleted).ToList();

        public List<Topic> GetTopicsByTrainingId(int id)
        {
            return _context.Topic.Where(t => t.Training.Any(t => !t.IsDeleted && t.Id == id)).ToList();
        }



        public void AddTopic(Topic model)
        {
            _context.Topic.Add(model);
            _context.SaveChanges();
        }

        public void UpdateTopic(Topic model, int id)
        {
            var entity = GetTopicById(id);
            entity.Name = model.Name;
            _context.SaveChanges();
        }

        public void ChangeDeleteStatus(Topic topic, bool IsDeleted)
        {
            topic.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}