using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API.Models.OutputModel
{
    public class EventOutputModel
    {
        public string StartDate { get; set; }
        public CompanyModel? Company { get; set; }
        public ClassroomModel Classroom { get; set; }
        public LecturerModel Lecturer { get; set; }
        public List<ClientModel>? Clients { get; set; }
    }
}
