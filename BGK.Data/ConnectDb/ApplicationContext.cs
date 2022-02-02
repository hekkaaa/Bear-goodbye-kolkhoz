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
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WIN-4PTG0MGAJ62\SQLEXPRESS;Database=testSS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Training>().HasData(
            new Training()
            {
                Id = 1,
                Name = "Развитие ораторских способностей",
                Description = "Тренинг для развития ораторских способностей, лучшие приглашенные ораторы всех времён",
                Duration = 3,
                MembersCount = 15,
                Price = 1500
            },
            new Training()
            {
                Id = 2,
                Name = "Нетворк-скиллы",
                Description = "Тренинг для развития скиллов нетворкинга, знакомьтесь везде и всегда",
                Duration = 5,
                MembersCount = 18,
                Price = 2000
            },
            new Training()
            {
                Id = 3,
                Name = "Сторителлинг",
                Description = "Научитесь рассказывать истории, захватывайте всех своими презентациями",
                Duration = 2,
                MembersCount = 10,
                Price = 3500
            }
            );

            modelBuilder.Entity<Lecturer>().HasData(
                new Lecturer() { Id = 1, Name = "Вячеслав Ибрагимович", LastName = "Пототько", BirthDay = "27 августа", Gender = Enums.Gender.Male },
                new Lecturer() { Id = 2, Name = "Евгения Владимировна", LastName = "Цыплухина", BirthDay = "22 сентября", Gender = Enums.Gender.Female },
                new Lecturer() { Id = 3, Name = "Андрей Андреевич", LastName = "Вейпов", BirthDay = "15 октября", Gender = Enums.Gender.Male }
            );

            modelBuilder.Entity<Classroom>().HasData(
            new Classroom() { Id = 1, Address = "ул. Вавилова дом 5", City = "Санкт-Петербург", MembersCount = 25 },
            new Classroom() { Id = 2, Address = "пр. Ветеранов дом 8", City = "Санкт-Петербург", MembersCount = 25 },
            new Classroom() { Id = 3, Address = "ул. Пушкина дом 27", City = "Санкт-Петербург", MembersCount = 40 }
            );

        }

    }
}
