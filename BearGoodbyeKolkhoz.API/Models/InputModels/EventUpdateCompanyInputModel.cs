using BearGoodbyeKolkhozProject.Business.Models;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class EventUpdateCompanyInputModel
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public CompanyModel? Company { get; set; }
        public ClassroomModel Classroom { get; set; }
        public LecturerModel Lecturer { get; set; }
    }
}
