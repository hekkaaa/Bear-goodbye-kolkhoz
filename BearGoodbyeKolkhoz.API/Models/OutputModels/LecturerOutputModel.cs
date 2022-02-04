using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.API.Models.OutputModels
{
    public class LecturerOutputModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string? BirthDay { get; set; }
        public bool IsDeleted { get; set; }
        public Gender Gender { get; set; }

        //public virtual ICollection<Training> Trainings { get; set; }
        //public virtual ICollection<Event> Events { get; set; }
        //public virtual ICollection<LecturerReview> LecturerReviews { get; set; }
    }
}