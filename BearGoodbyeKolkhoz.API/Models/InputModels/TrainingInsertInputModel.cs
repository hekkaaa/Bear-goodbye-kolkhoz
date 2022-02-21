namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TrainingInsertInputModel
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int MembersCount { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
    }
}
