using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class EventUpdateClientInputModel
    {
        public int Id { get; set; } 
        public string StartDate { get; set; }
        public ClassroomModel Classroom { get; set; }
        public LecturerModel Lecturer { get; set; }
        public List<ClientModel>? Clients { get; set; }
    }
}
