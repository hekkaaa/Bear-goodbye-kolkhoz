using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class EventUpdateInputModel
    {
        public DateTime StartDate { get; set; }
        public EventPartialUpdateInputModel? Classroom { get; set; }
        public EventPartialUpdateInputModel? Lecturer { get; set; }
        public EventPartialUpdateInputModel? Training { get; set; }

    }
}
