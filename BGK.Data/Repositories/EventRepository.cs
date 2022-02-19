using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class EventRepository : IEventRepository
    {

        private ApplicationContext _context;

        public EventRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public Event GetEventById(int id) =>
            _context.Event.Find(id);

        public List<Event> GetEvents() =>
            _context.Event.Where(e => !e.IsDeleted).ToList();

        public void AddEvent(Event even)
        {
            _context.Event.Add(even);

            _context.SaveChanges();

        }

        public void UpdateEvent(Event even)
        {
            var entity = GetEventById(even.Id);

            entity.StartDate = even.StartDate;
            entity.Clients = even.Clients;
            entity.Company = even.Company;
            entity.Classroom = even.Classroom;
            entity.Lecturer = even.Lecturer;

            _context.Event.Update(entity);

            _context.SaveChanges();


        }

        public void DeleteEvent(Event even)
        {            

            _context.Event.Remove(even);

            _context.SaveChanges();
        }
    }
}
