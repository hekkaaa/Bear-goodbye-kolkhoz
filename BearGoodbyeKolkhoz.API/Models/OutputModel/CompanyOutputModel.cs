using BearGoodbyeKolkhozProject.Data.Entities;

namespace BearGoodbyeKolkhozProject.API.Models.OutputModel
{
    public class CompanyOutputModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Tin { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
       

    }
}
