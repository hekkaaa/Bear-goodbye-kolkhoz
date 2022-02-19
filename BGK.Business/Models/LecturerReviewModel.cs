using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Business.Models
{
    public class LecturerReviewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public bool IsDeleted { get; set; }

        public ClientModel Client { get; set; }
        public LecturerModel LecturerModel { get; set; }

        public override string ToString()
        {
            return $"{Id} {Text} {Mark}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is null
                || Id != ((LecturerReviewModel)obj).Id
                || Text != ((LecturerReviewModel)obj).Text
                || Mark != ((LecturerReviewModel)obj).Mark
                || Client != ((LecturerReviewModel)obj).Client)
            {
                return false;
            }

            return true;
        }
    }
}
