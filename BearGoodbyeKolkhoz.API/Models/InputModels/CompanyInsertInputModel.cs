namespace BearGoodbyeKolkhozProject.API.Models
{
    public class CompanyInsertInputModel : CompanyUpdateInputModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

    }
}
