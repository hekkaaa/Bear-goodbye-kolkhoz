using Microsoft.EntityFrameworkCore;

namespace BearGoodbyeKolkhozProject.Data.ConnectDb
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Entities.Admin> Admin { get; set; } = null!;
        public DbSet<Entities.Classroom> Classroom { get; set; }

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
