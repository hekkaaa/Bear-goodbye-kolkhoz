﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("LecturerReview")]
    public  class LecturerReview
    {
        public int Id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Lecturer Lecturer { get; set; }

        public string Text { get; set; }

        public int Mark { get; set; }

    }
}
