using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data.Repositories
{
    public class LecturerReviewRepository
    {
        private ApplicationContext _context = Storage.GetInstance();

        public LecturerReview GetLecturerReviewById(int id)
        {
            return _context.LecturerReview.Find(id);
        }

        public List<LecturerReview> GetLecturerReviews()
        {
            return _context.LecturerReview.ToList();
        }

        public List<LecturerReview> GetLecturerReviewsByLecturerId(int id)
        {
            return _context.LecturerReview.Where(lr => lr.Lecturer.Id == id).ToList();
        }

        public void AddLecturerReview(LecturerReview model)
        {
            _context.LecturerReview.Add(model);
            _context.SaveChanges();
        }

        public void DeleteLecturerReviewById(int id)
        {
            _context.LecturerReview.Remove(GetLecturerReviewById(id));
        }
    }
}
