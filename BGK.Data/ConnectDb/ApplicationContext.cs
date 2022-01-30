using Microsoft.EntityFrameworkCore;

namespace BearGoodbyeKolkhozProject.Data.ConnectDb
{
    public class ApplicationContext : DbContext
    {
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
        public DbSet<Entities.TrainingClient> TrainingClient { get; set; }
        public DbSet<Entities.TrainingReview> TrainingReview { get; set; }

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
