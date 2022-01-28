using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("TrainingReview")]
    public  class TrainingReview
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        public Training Training { get; set; }

        public string Text { get; set; }

        public int Mark { get; set; }
    }
}
