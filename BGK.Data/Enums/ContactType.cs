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
        Instagram,
        VK,
        WhatsApp,
        Facebook
    }
}
