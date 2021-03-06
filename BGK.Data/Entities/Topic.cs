using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BearGoodbyeKolkhozProject.Data.Entities
{
    [Table("Topic")]
    public class Topic
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Client>? Client { get; set; }
        public virtual ICollection<Training>? Training { get; set; }
        public override bool Equals(object? obj)
        {
            if (obj is null
                || Id != ((Topic)obj).Id
                || Name != ((Topic)obj).Name
                || IsDeleted != ((Topic)obj).IsDeleted
                || Training != ((Topic)obj).Training
                || Client != ((Topic)obj).Client)
            {
                return false;
            }

            return true;
        }
    }
}