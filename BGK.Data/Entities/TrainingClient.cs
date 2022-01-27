using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGK.Data.Entities
{
    //[Table("Admin")]
    public class TrainingClient
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        public Event Event { get; set; }


    }
}
