using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Enums;
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
        public DbSet<User> User { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Lecturer>().ToTable("Lecturer");
            modelBuilder.Entity<Client>().ToTable("Client");

            modelBuilder.Entity<Admin>().HasData(
            new Admin()
            {
                Id = 1,
                Name = "Admin",
                LastName = "Admin",
                Gender = Gender.Male,
                BirthDay = "01.01.2000",
                Email = "Admin@mail.ru",
                Password = "1000:WvGHoK1WF2vO/ZkCz8FcmEdWsULri96e:oYQNDwkRfTN2Sm1fY56gS/5esvc=",
                Role = Role.Admin,
                IsDeleted = false,
            }
            );


            modelBuilder.Entity<Classroom>().HasData(
            new Classroom() { Id = 1, Address = "ул. Вавилова дом 5", City = "Санкт-Петербург", MembersCount = 25 },
            new Classroom() { Id = 2, Address = "пр. Ветеранов дом 8", City = "Санкт-Петербург", MembersCount = 25 },
            new Classroom() { Id = 3, Address = "ул. Пушкина дом 27", City = "Санкт-Петербург", MembersCount = 40 }
            );

        }

    }
}