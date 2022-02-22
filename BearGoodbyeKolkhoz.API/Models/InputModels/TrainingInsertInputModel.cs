using System.ComponentModel.DataAnnotations;

namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TrainingInsertInputModel
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int MembersCount { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
