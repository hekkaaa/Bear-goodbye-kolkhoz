using BearGoodbyeKolkhozProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BearGoodbyeKolkhozProject.Data.ConnectDb
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Admin> Admin { get; set; } = null!;
        public DbSet<Classroom> Classroom { get; set; }
        public DbSet<Client> Client { get; set; } = null!;
        public DbSet<Company> Company { get; set; }
        public DbSet<ContactLecturer> ContactLecturer { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<LecturerReview> LecturerReview { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<TrainingReview> TrainingReview { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Data Source=tcp:localhost,1434;Network Library=DBMSSOCN;Initial Catalog=Testmaster1;User ID=SA;Password=Qwerty123;");
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-6F8LE3JH\SQLEXPRESSDEV;Initial Catalog=Newtest;Integrated Security=True");

            //"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Newtest;Integrated Security=True";
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Newtest;Trusted_Connection=True;");
        }
    }
}
