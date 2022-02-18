using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Business.Processor;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repositories;


namespace BearGoodbyeKolkhozProject.Business.Services
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
            if (even == null)
                throw new BusinessException("Такого события не существует.");

            return _mapper.Map<EventModel>(even);
        }

        public List<EventModel> GetEvents()
        {
            List<Event> events = _eventRepository.GetEvents();

            return _mapper.Map<List<EventModel>>(events);
        }


        public void AddEventFromCompany(EventModel eventModel)
        {

            _eventRepository.AddEvent(_mapper.Map<Event>(eventModel));

        }

        public void AddEventFromClient(EventModel eventModel)
        {

            _eventRepository.AddEvent(_mapper.Map<Event>(eventModel));
        }

        public void UpdateEvent(int id, EventModel eventModel)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new BusinessException("Такого события не существует!");


            _eventRepository.UpdateEvent(_mapper.Map<Event>(eventModel));

        }
      

        public void DeleteEvent(int id)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new BusinessException($"Такого события {id} не существует.");

            _eventRepository.DeleteEvent(id);
        }

    }
}
