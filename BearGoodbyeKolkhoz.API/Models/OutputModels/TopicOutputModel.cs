namespace BearGoodbyeKolkhozProject.API.Models
{
    public class TopicOutputModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TrainingOutputModel Training { get; set; }
    }
}