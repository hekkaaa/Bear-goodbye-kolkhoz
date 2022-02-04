using BearGoodbyeKolkhozProject.Business.Models;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Processor
{
    public class EventService
    {
        private readonly EventRepository eventRepository;

        public void AddEventFromCompany(int id, EventModel eventModel)
        {
            var @event = eventRepository.GetEventById(id);
            if (@event != null)
                throw new Exception("Такой событие уже существует!");

            var mappedEvent = new Event
            {
                StartDate = eventModel.StartDate,
                Company = eventModel.Company,
                Classroom = eventModel.Classroom,
                Lecturer = eventModel.Lecturer
            };

            eventRepository.AddEvent(mappedEvent);
        }
        public void AddEventFromClient(int id, EventModel eventModel)
        {
            var @event = eventRepository.GetEventById(id);
            if (@event != null)
                throw new Exception("Такой событие уже существует!");

            var mappedEvent = new Event
            {
                StartDate = eventModel.StartDate,
                Clients = eventModel.Clients,
                Classroom = eventModel.Classroom,
                Lecturer = eventModel.Lecturer,
                IsDeleted = eventModel.IsDeleted
            };

            eventRepository.AddEvent(mappedEvent);
        }

        public void UpdateEventFromClient(int id, EventModel eventModel)
        {
            var @event = eventRepository.GetEventById(id);
            if (@event == null)
                throw new Exception("Такого события не существует!");

            var mappedEvent = new Event
            {
                StartDate = eventModel.StartDate,
                Clients = eventModel.Clients,
                Classroom = eventModel.Classroom,
                Lecturer = eventModel.Lecturer
            };

            eventRepository.UpdateEvent(mappedEvent);
        }
        public void UpdateEventFromCompany(int id, EventModel eventModel)
        {
            var @event = eventRepository.GetEventById(id);
            if (@event == null)
                throw new Exception("Такого события не существует!");

            var mappedEvent = new Event
            {
                StartDate = eventModel.StartDate,
                Company = eventModel.Company,
                Classroom = eventModel.Classroom,
                Lecturer = eventModel.Lecturer
            };

            eventRepository.UpdateEvent(mappedEvent);
        }

        public void DeleteEvent(int id, bool isDel)
        {
            var @event = eventRepository.GetEventById(id);
            if (@event == null)
                throw new Exception("Такого события не существует!");

            eventRepository.UpdateEvent(id, isDel);
        }
    }
}
