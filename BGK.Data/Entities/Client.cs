using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGK.Data.Entities
{
    public  class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SurnName { get; set; }

        public bool Gender { get; set; }

        public string BirthDay { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public string Password { get; set; }


    }
}
