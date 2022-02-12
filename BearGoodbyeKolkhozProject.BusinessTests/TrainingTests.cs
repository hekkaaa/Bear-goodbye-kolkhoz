using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;


namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class TrainingTests
    {
        private TrainingService _service;
        private ApplicationContext _context;
        private TrainingRepository _trainingRepository;


        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "Memory-DB")
               .Options;
            _context = new ApplicationContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            _trainingRepository = new TrainingRepository(_context);
            _service = new TrainingService(_trainingRepository);

        }

        [Test]
        public void GetTrainingByIdNegativeTests()
        {
            //given
            //when
            var act = _service.GetTrainingModelById(5);
            //then
            Assert.Throws<RepositoryException>(() => { throw new RepositoryException("Такого тренинга не найдено!"); });
        }

    }
}
