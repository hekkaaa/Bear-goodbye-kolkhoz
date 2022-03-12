using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class EventUpdateInputModel
    {
        public DateTime StartDate { get; set; }
        public TestInputModel? Classroom { get; set; }
        public TestInputModel? Lecturer { get; set; }
        public TestInputModel? Training { get; set; }


        //public DateTime StartDate { get; set; }
        //public CompanyModel? Company { get; set; }
        //public ClassroomModel Classroom { get; set; }
        //public LecturerModel Lecturer { get; set; }
        //public List<ClientModel>? Clients { get; set; }
    }
}
