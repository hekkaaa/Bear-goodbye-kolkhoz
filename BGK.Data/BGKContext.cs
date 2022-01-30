using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BearGoodbyeKolkhozProject.Data
{
    public class BGKContext : DbContext
    {
        public BGKContext(DbContextOptions<BGKContext> options) : base(options)
        {
            //Database.SetInitializer<BGKContext>(new BGKDBInitializer());
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test");
            optionsBuilder.
        }

       
        public DbSet<Entities.Admin> Admin { get; set; } = null!;
        public DbSet<Entities.Classroom> Classroom { get; set; }
        public DbSet<Entities.Client> Client { get; set; } = null!;
        public DbSet<Entities.Company> Company { get; set; }
        public DbSet<Entities.ContactLecturer> ContactLecturer { get; set; }
        public DbSet<Entities.Event> Event { get; set; }
        public DbSet<Entities.Lecturer> Lecturer { get; set; }
        public DbSet<Entities.LecturerReview> LecturerReview { get; set; }
        public DbSet<Entities.Topic> Topic { get; set; }
        public DbSet<Entities.Training> Training { get; set; }
        public DbSet<Entities.TrainingReview> TrainingReview { get; set; }
    }
}
