﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Training")]
    public class Training
    {
        public int Id { get; set; }

        [StringLength(40)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public bool IsDeleted { get; set; }

        public int MembersCount { get; set; }

        public int Duration { get; set; }

        public int Price { get; set; }

        public virtual ICollection<TrainingReview> TrainingReviews { get; set; }


    }
}
