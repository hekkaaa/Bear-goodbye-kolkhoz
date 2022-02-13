using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class TopicRepository
    {
        private ApplicationContext _context;

        public TopicRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Topic GetTopicById(int id) => 
            _context.Topic.FirstOrDefault(t => t.Id == id);

        public List<Topic> GetTopic() => 
            _context.Topic.Where(t => !t.IsDeleted).ToList();

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

        public void ChangeDeleteStatusById(int id, bool IsDeleted)
        {
            var entity = _context.Topic.FirstOrDefault(t => t.Id == id);
            entity.IsDeleted = IsDeleted;
            _context.SaveChanges();
        }
    }
}