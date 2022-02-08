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

     

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {           
            Database.EnsureCreated();
        }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-5HF0J14\SQLEXPRESS;Initial Catalog=BGKdb;Integrated Security=True");
            
        }
    }
}
