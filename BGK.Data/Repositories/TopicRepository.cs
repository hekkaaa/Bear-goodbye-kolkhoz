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
        private ApplicationContext _context = Storage.GetInstance();

        public Topic GetTopicById(int id)
        {
            return _context.Topic.Find(id);
        }

        public List<Topic> GetTopic()
        {
            return _context.Topic.ToList();
        }

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

        public void DeleteTopicById(int id)
        {
            var entity = GetTopicById(id);
            entity.IsDeleted = true;
            _context.SaveChanges();
        }

        public void RecoverTopicById(int id)
        {
            var entity = _context.Topic.Find(id);
            entity.IsDeleted = false;
            _context.SaveChanges();
        }
    }
}
