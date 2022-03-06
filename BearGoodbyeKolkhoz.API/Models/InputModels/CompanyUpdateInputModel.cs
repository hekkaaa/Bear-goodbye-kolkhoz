using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models.InputModels
{
    public class CompanyUpdateInputModel
    {
        public string Name { get; set; }
        [Range(1, 9999999999, ErrorMessage = "Value for {0} must be between {1} and {2}. | Значение {0} должно быть в диапазоне от {1} до {2}")]
        public long Tin { get; set; }
        public string PhoneNumber { get; set; }
    }
        
}
