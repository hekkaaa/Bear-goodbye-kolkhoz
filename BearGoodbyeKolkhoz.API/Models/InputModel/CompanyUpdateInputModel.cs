using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class CompanyUpdateInputModel
    {
        public string Name { get; set; }
        public int Tin { get; set; }
        public string PhoneNumber { get; set; }
     
    }
}
