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
            _context.Topic.FirstOrDefault(t => t.Id == id);

        public List<Topic> GetTopics() =>
            _context.Topic.Where(t => !t.IsDeleted).ToList();

        public List<Topic> GetTopicsByTrainingId(int id) =>
            _context.Topic.Where(t => !t.IsDeleted).Where(t => t.Training.Id == id).ToList();

        public void AddTopic(Topic model)
        {
            _context.Topic.Add(model);
            _context.SaveChanges();
        }

        public void UpdateTopic(Topic model)
        {
            var entity = GetTopicById(model.Id);
            entity.Name = model.Name;
            _context.SaveChanges();
        }

        public void ChangeDeleteStatusById(Topic topic, bool isDeleted)
        {
            var entity = _context.Topic.FirstOrDefault(t => t.Id == topic.Id);
            entity.IsDeleted = isDeleted;
            _context.SaveChanges();
        }
    }
}