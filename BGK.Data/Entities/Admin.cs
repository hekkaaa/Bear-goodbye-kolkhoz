using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGK.Data.Entities
{
    public class Admin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public bool Gender { get; set; }

        public string BirhtDay { get; set; }

        public string Emaill { get; set; }

        public string Password { get; set; }
    }
}
