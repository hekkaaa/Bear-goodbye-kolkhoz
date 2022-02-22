
namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class TopicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public TrainingModel? Training { get; set; }
        public ClientModel? Client { get; set; }
        public LecturerModel? Lecturer { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null
                || Id != ((TopicModel)obj).Id
                || Name != ((TopicModel)obj).Name
                || IsDeleted != ((TopicModel)obj).IsDeleted
                || Training != ((TopicModel)obj).Training
                || Client != ((TopicModel)obj).Client
                || Lecturer != ((TopicModel)obj).Lecturer)
            {
                return false;
            }

            return true;
        }
    }
}
