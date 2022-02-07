using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Data.Repo
{
    public interface IEventRepository
    {
        void AddEvent(Event even);
        void DeleteEvent(int id);
        Event GetEventById(int id);
        List<Event> GetEvents();
        void UpdateEvent(Event even);
        void UpdateEvent(int id, bool isDel);
    }
}