using BearGoodbyeKolkhozProject.Data.ConnectDb;
using BearGoodbyeKolkhozProject.Data.Repo;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace BearGoodbyeKolkhozProject.Data.Tests
{
    public class EventRepositoryTests
    {
        private ApplicationContext _context;

        private EventRepository _eventRepository;

        private readonly Mock<IEventRepository> _mock;

        public EventRepositoryTests()
        {
            _mock = new Mock<IEventRepository>();

        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "Test")
                .Options;

            _context = new ApplicationContext(options);

            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            _eventRepository = new EventRepository(_context);
        }

        

    }
}
