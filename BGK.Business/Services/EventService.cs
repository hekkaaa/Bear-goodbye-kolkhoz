using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;

namespace BearGoodbyeKolkhozProject.Business.Processor
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public EventModel GetEventById(int id)
        {
            var even = _eventRepository.GetEventById(id);
            if (even != null)
                throw new Exception("Такого события не существует.");

            return CustomMapper.GetInstance().Map<EventModel>(even);
        }

        public List<EventModel> GetEvents()
        {
            List<Event> events = _eventRepository.GetEvents();

            return CustomMapper.GetInstance().Map<List<EventModel>>(events);
        }


        public void AddEventFromCompany(EventModel eventModel)
        {

            _eventRepository.AddEvent(CustomMapper.GetInstance().Map<Event>(eventModel));

        }

        public void AddEventFromClient(EventModel eventModel)
        {

            _eventRepository.AddEvent(CustomMapper.GetInstance().Map<Event>(eventModel));
        }

        public void UpdateEventFromClient(int id, EventModel eventModel)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new Exception("Такого события не существует!");


            _eventRepository.UpdateEvent(CustomMapper.Custom.Map<Event>(eventModel));


        }

        public void UpdateEventFromCompany(int id, EventModel eventModel)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new Exception("Такого события не существует!");


            _eventRepository.UpdateEvent(CustomMapper.Custom.Map<Event>(eventModel));
        }

        public void DeleteEvent(int id, bool isDel)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new Exception("Такого события не существует!");

            _eventRepository.UpdateEvent(id, isDel);
        }
    }
}
