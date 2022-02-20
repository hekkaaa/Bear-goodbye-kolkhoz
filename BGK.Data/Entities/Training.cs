using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Training")]
    public class Training
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string? Name { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public int MembersCount { get; set; }
        public int Duration { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TrainingReview> TrainingReviews { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<Lecturer> Lecturer { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is null
                || Id != ((Training)obj).Id
                || Name != ((Training)obj).Name
                || Description != ((Training)obj).Description
                || MembersCount != ((Training)obj).MembersCount
                || Duration != ((Training)obj).Duration
                || Price != ((Training)obj).Price
                || IsDeleted != ((Training)obj).IsDeleted)
            {
                return false;
            }
            return true;
        }
    }
}
