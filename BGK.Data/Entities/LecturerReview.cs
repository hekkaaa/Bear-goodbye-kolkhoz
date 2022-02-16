using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("LecturerReview")]
    public class LecturerReview
    {
        public int Id { get; set; }
        [StringLength(320)]
        public string Text { get; set; }
        public int Mark { get; set; }

        public virtual Client Client { get; set; }
        public virtual Lecturer Lecturer { get; set; }

        public override string ToString()
        {
            return $"{Id} {Text}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null
                || Id != ((LecturerReview)obj).Id
                || Text != ((LecturerReview)obj).Text
                || Mark != ((LecturerReview)obj).Mark
                || Client != ((LecturerReview)obj).Client
                || Lecturer != ((LecturerReview)obj).Lecturer)
            {
                return false;
            }

            return true;
        }
    }
}
