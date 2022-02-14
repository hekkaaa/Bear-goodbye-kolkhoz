using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IEventService
    {
        void AddEventFromClient(EventModel eventModel);
        void AddEventFromCompany(EventModel eventModel);
        void DeleteEvent(int id);
        EventModel GetEventById(int id);
        List<EventModel> GetEvents();
        void UpdateEventFromClient(int id, EventModel eventModel);
        void UpdateEventFromCompany(int id, EventModel eventModel);
        public void UpdateEvent(int id, bool isDel);
    }
}