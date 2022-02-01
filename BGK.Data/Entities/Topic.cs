using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Topic")]
    public class Topic
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

    }
}
