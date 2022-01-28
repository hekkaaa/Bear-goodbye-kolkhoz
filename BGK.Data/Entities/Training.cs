﻿using System;
using System.Collections.Generic;
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

        public string? Name { get; set; }

        public string? Description { get; set; }

    }
}
