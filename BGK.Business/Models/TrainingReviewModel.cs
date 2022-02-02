using BearGoodbyeKolkhozProject.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class TrainingReviewModel
    {
        public int Id { get; set; }
        public virtual ClientModel Client { get; set; }
        public virtual TrainingModel Training { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }

    }
}
