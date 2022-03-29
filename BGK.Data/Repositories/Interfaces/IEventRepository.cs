using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public interface IEventRepository
    {
        void AddEvent(Event even);
        void DeleteEvent(Event even);
        Event GetEventById(int id);
        List<Event> GetEvents();
        void UpdateEvent(Event even);
        void UpdateEvent(Event even, bool isDeleted);
        bool PartialUpdateEvent(Event oldEvent, Event newEvent);
        void SignUp(Client client, Event even);
        Event GetEventsByTrainingId(int trainingId);
        List<Event> GetClosedRegEvents();
        List<Event> GetCompletedEventsByLecturer(Lecturer lecturer, DateTime date);
        List<Event> GetAttendedEventsByClient(Client client, DateTime date);
    }
}