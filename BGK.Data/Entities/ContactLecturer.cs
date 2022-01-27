using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGK.Data.Entities
{
    public class ContactLecturer
    {
        public int Id { get; set; }

        public ContacType ContacType { get; set; } 

        public Lecturer Lecturer { get; set; }

        public string Value { get; set; }
    }
}
