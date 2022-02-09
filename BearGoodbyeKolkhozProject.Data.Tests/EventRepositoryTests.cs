using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Entities;
using BearGoodbyeKolkhozProject.Data.Repo;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class EventRepositoryTests
    {
        private ApplicationContext _context;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            _context = new ApplicationContext(options);

            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            ;
        }



        //public class AddEventTestCaseSource : IEnumerable
        //{
        //    public IEnumerator GetEnumerator()
        //    {
        //        var even = new Event
        //        {
        //            Id = 1,
        //            StartDate = "03.03.2022",
        //            Company = 1,
        //            Classroom = 1,
        //            Lecturer = 2,

        //        };

        //        yield return new object[] { even };


        //        //}
        //    }
        //}
    }
}