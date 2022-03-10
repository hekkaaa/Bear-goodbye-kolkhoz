using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class LecturerModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? IsDeleted { get; set; }
        public Gender? Gender { get; set; }

        public List<TrainingModel>? Trainings { get; set; }
        public List<Event>? Events { get; set; }
        public List<LecturerReview>? LecturerReviews { get; set; }
    }
}
