using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repo
{
    public class EventRepository
    {
        private ApplicationContext _context;

        public Event GetEventById(int id) =>
            _context.Event.Find(id);


        public void AddEvent(Event @event)
        {
            var excistanEvent = GetEventById(@event.Id);

            _context.SaveChanges();

        }

        public void UpdateEvent(Event @event)
        {
            var entity = GetEventById(@event.Id);
            entity.Clients = @event.Clients;
            entity.Company = @event.Company;
            entity.Classroom = @event.Classroom;
            entity.Lecturer = @event.Lecturer;
            entity.IsDeleted = @event.IsDeleted;

            _context.SaveChanges();


        }

        public void UpdateEvent(int id, bool isDel)
        {

            var entity = GetEventById(id);

            entity.IsDeleted = isDel;

            _context.SaveChanges();

        }

        public void DeleteEvent(int id)
        {
            var entity = GetEventById(id);

            _context.Event.Remove(entity);

            _context.SaveChanges();
        }







    }
}
