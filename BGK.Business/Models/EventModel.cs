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
        int Id { get; set; }
        string StartDate { get; set; }

        Company? Company { get; set; }
        Classroom Classroom { get; set; }

        Lecturer Lecturer { get; set; }

        bool IsDeleted { get; set; }

        List<Client>? Clients { get; set; }

    }
}
