using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string StartDate { get; set; }
        public Company Company { get; set; }
        public Classroom Classroom { get; set; }
        public Lecturer Lecturer { get; set; }
        public  bool IsDeleted { get; set; }
        public List<Client> Clients { get; set; }

    }
}
