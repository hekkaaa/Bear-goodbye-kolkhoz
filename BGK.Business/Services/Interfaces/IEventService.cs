using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.Business.Interface
{
    public interface IEventService
    {
        void AddEvent(EventModel eventModel);
        void DeleteEvent(int id);
        EventModel GetEventById(int id);
        List<EventModel> GetEvents();
        bool UpdateEvent(int id, EventModel eventModel);
        int SignUp(int trainingId, int clientId);
        List<EventModel> GetCompletedEventsByLecturerId(int id);
        List<EventModel> GetAttendedEventsByClientId(int id);
        void RestoreEvent(int id);
    }
}