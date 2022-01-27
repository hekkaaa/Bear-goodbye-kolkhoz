using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGK.Data.Entities
{
    public  class LecturerReview
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        public Lecturer Lecturer { get; set; }

        public string  Text { get; set; }

        public int Mark { get; set; }

    }
}
