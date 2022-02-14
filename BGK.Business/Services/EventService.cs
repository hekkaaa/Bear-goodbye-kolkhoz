using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (even != null)
                throw new Exception("Такого события не существует.");

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

        public void UpdateEventFromClient(int id, EventModel eventModel)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new Exception("Такого события не существует!");


            _eventRepository.UpdateEvent(_mapper.Map<Event>(eventModel));


        }

        public void UpdateEventFromCompany(int id, EventModel eventModel)
        {
            var even = _eventRepository.GetEventById(id);
            if (even == null)
                throw new Exception("Такого события не существует!");


            _eventRepository.UpdateEvent(_mapper.Map<Event>(eventModel));
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
