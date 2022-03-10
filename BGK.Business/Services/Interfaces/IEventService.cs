using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Interface
{
    public interface IEventService
    {
        void AddEvent(EventModel eventModel);
        void DeleteEvent(int id);
        EventModel GetEventById(int id);
        List<EventModel> GetEvents();
        void UpdateEvent(int id, EventModel eventModel);
        bool SignUp(int trainingId, int clientId);
        List<EventModel> GetCompletedEventsByLecturerId(int id);
        List<EventModel> GetAttendedEventsByClientId(int id);
    }
}