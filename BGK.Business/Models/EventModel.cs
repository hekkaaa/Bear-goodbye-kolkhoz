using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public  CompanyModel Company { get; set; }
        public  ClassroomModel Classroom { get; set; }
        public  LecturerModel Lecturer { get; set; }
        public  bool IsDeleted { get; set; }
        public  List<ClientModel> Clients { get; set; }

    }
}
