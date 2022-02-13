using AutoMapper;
using BearGoodbyeKolkhozProject.Business.Configuration;
using BearGoodbyeKolkhozProject.Business.Exceptions;
using BearGoodbyeKolkhozProject.Business.Services;
using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace BearGoodbyeKolkhozProject.Business.Tests
{
    public class Tests
    {
        private TrainingReviewService _service;
        private ApplicationContext _context;
        private TrainingReviewRepository _trainingRepository;
        private TestData _testData;

        [SetUp]
        public void Setup()
        {



            var options = new DbContextOptionsBuilder<ApplicationContext>()
               .UseInMemoryDatabase(databaseName: "Memory-DB")
               .Options;
            _context = new ApplicationContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new BusinessMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            _trainingRepository = new TrainingReviewRepository(_context);
            _service = new TrainingReviewService(_trainingRepository, mapper);

            _testData = new TestData();

        }

        [Test]
        public void UpdateTrainingReviewNegativeTests()
        {
            //given
            var trainingReviewModel = _testData.GetTrainingReviewModel();
            //when
            //then
            Assert.Throws<BusinessException>(() => _service.UpdateTrainingReview(666, trainingReviewModel));
        }

        [Test]
        public void GetTrainingReviewByIdNegativeTests()
        {
            //given
            //when
            //then
            Assert.Throws<BusinessException>(() => _service.GetTrainingReviewModelById(666));
        }

        [Test]
        public void GetTrainingReviewModels()
        {
            //given
            //when
            //then
            Assert.Throws<BusinessException>(() => _service.GetTrainingReviewModels());
        }

        [Test]
        public void DeleteTrainingReviewNegativeTests()
        {
            //given
            var trainingReviewModel = _testData.GetTrainingReviewModel();
            trainingReviewModel.Id = 666;

            //when
            //then
            Assert.Throws<BusinessException>(() => _service.DeleteTrainingReview(trainingReviewModel));

        }

    }
}