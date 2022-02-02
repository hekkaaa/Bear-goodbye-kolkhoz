using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.API.Models.InputModel
{
    public class EventUpdateInputModel
    {
        public string StartDate { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Classroom Classroom { get; set; }
        public virtual Lecturer Lecturer { get; set; }

        public virtual List<Client>? Clients { get; set; }
    }
}
