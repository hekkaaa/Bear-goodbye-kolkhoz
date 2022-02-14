namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class CompanyUpdateInputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Tin { get; set; }
        public string PhoneNumber { get; set; }

        public bool IsDelete { get; set; }
    }
}
