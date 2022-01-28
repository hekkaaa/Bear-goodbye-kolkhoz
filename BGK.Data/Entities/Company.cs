using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Company")]
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        
        [StringLength(10)]
        public int Tin { get; set; }

        public string Email { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }


    }
}
