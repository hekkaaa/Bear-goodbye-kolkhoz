using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models.OutputModels
{
    public class CompanyOutputModel
    {   
        public int Id { get; set; }
        public string Name { get; set; }
        public long Tin { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}
