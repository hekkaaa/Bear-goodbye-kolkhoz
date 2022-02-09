using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repo
{
    public class EventRepository : IEventRepository
    {
        private ApplicationContext _context;

        public EventRepository(ApplicationContext context)
        {
            _context = context;
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
            entity.Clients = even.Clients;
            entity.Company = even.Company;
            entity.Classroom = even.Classroom;
            entity.Lecturer = even.Lecturer;

            _context.SaveChanges();


        }

        public void UpdateEvent(int id, bool isDel)
        {

            var entity = _context.Event.FirstOrDefault(x => x.Id == id);

            entity.IsDeleted = isDel;

            _context.SaveChanges();

        }

        public void DeleteEvent(Event even)
        {
            
            _context.Event.Remove(even);

            _context.SaveChanges();
        }


    }
}
