using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Entities
{

    public enum ContactType
    {
        Telegram = 1,
        Instagram = 2,
        Phone = 3,
        Vk = 4,
        Facebook = 5,
        Whatsapp = 6,
        Email = 7
    }
}
