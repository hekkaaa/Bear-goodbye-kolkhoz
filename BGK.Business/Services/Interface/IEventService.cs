namespace BearGoodbyeKolkhozProject.Business.Services
{
    public interface IEventService
    {
        void AddEventFromClient(EventModel eventModel);
        void AddEventFromCompany(EventModel eventModel);
        void DeleteEvent(int id, bool isDel);
        EventModel GetEventById(int id);
        List<EventModel> GetEvents();
        void UpdateEventFromClient(int id, EventModel eventModel);
        void UpdateEventFromCompany(int id, EventModel eventModel);
    }
}