using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;

namespace BearGoodbyeKolkhozProject.Business.Processor
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;

        private IMapper _mapper;

        public EventService(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public EventModel GetEventById(int id)
        {
            var even = _eventRepository.GetEventById(id);
            if (even != null)
                throw new NotAuthorizedException($"Такого события {id} не существует.");

            return _mapper.Map<EventModel>(even);
        }

        public List<EventModel> GetEvents()
        {
            List<Event> events = _eventRepository.GetEvents();

            return _mapper.Map<List<EventModel>>(events);
        }


        public void AddEventFromCompany(EventModel eventModel)
        {
            //var mappedEvent = new Event
            //{
            //    StartDate = eventModel.StartDate,
            //    Company = eventModel.Company,
            //    Classroom = eventModel.Classroom,
            //    Lecturer = eventModel.Lecturer,
            //    IsDeleted = eventModel.IsDeleted
            //};

            _eventRepository.AddEvent(_mapper.Map<Event>(eventModel));

        }

        public void AddEventFromClient(EventModel eventModel)
        {

            _eventRepository.AddEvent(_mapper.Map<Event>(eventModel));
        }

        public void UpdateEventFromClient(int id, EventModel eventModel)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new NotAuthorizedException($"Такого события {id} не существует.");


            _eventRepository.UpdateEvent(_mapper.Map<Event>(eventModel));


        }

        public void UpdateEventFromCompany(int id, EventModel eventModel)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new NotAuthorizedException($"Такого события {id} не существует.");


            _eventRepository.UpdateEvent(_mapper.Map<Event>(eventModel));
        }

        public void DeleteEvent(int id)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new NotAuthorizedException($"Такого события {id} не существует.");

            _eventRepository.DeleteEvent(even);
        }

        public void UpdateEvent(int id, bool isDel)
        {
            var even = _eventRepository.GetEventById(id);

            if (even == null)
                throw new NotAuthorizedException($"Такого события {id} не существует.");

            _eventRepository.UpdateEvent(id, isDel);
        }

       
        
    }
}
