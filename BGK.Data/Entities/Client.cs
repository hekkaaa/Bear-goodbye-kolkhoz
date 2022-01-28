using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Client")]
    public  class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurnName { get; set; }

        public bool Gender { get; set; }

        public string BirthDay { get; set; }

        public string Email { get; set; }

        [StringLength(20)]
        public int PhoneNumber { get; set; }

        public string Password { get; set; }

        //public List<Topic> topic { get; set; }

    }
}
