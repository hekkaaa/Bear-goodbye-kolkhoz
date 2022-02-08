using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class LecturerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string BirthDay { get; set; }
        public bool IsDeleted { get; set; }
        public Gender Gender { get; set; }

        public List<TrainingModel> Trainings { get; set; }
        public List<Event> Events { get; set; }
        public List<LecturerReview> LecturerReviews { get; set; }
    }
}
