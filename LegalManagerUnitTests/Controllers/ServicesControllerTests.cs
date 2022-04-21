namespace LegalManagerUnitTests.Controllers
{
    using LegalManager.Controllers;
    using System;
    using Xunit;
    using LegalManager.Models.Entities.Services;
    using LegalManager.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ServicesControllerTests
    {
        private ServicesController _testClass;
        private ApplicationDbContext _context;

        public ServicesControllerTests()
        {
            _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            _testClass = new ServicesController(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ServicesController(_context);
            
            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CannotCallCreateWithChosenServiceWithNullChosenService()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Create(default(ChosenService)));
        }
    }
}