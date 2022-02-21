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
        void SignUp(Client client, Event even);
        Event GetEventsByTrainingId(int trainingId);
    }
}