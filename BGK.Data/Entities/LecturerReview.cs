using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("LecturerReview")]
    public  class LecturerReview
    {
        public int Id { get; set; }
        [StringLength(320)]
        public string Text { get; set; }
        public int Mark { get; set; }

        public virtual Client Client { get; set; }
        public virtual Lecturer Lecturer { get; set; }
    }
}
