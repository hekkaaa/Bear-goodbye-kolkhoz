using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API.Models.InputModel
{
    public class EventUpdateInputModel
    {
        public string StartDate { get; set; }
        public  CompanyModel? Company { get; set; }
        public  ClassroomModel Classroom { get; set; }
        public  LecturerModel Lecturer { get; set; }
        public List<ClientModel>? Clients { get; set; }

    }
}
