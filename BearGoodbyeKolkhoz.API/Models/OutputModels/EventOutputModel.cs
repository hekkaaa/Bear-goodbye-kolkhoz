using BearGoodbyeKolkhozProject.API.Models.InputModels;
using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API.Models.OutputModels
{
    public class EventOutputModel
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public EventIdOutputInputModel? Company { get; set; }
        public EventIdOutputInputModel? Classroom { get; set; }
        public EventIdOutputInputModel Lecturer { get; set; }
        public List<EventIdOutputInputModel>? Clients { get; set; }

    }
}
