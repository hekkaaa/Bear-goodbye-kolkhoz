using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("TrainingClient")]
    public class TrainingClient
    {
        public int Id { get; set; }

        public virtual Client Client { get; set; }

        public virtual Event Event { get; set; }


    }
}
