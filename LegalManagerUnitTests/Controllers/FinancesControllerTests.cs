namespace LegalManagerUnitTests.Controllers
{
    using LegalManager.Controllers;
    using System;
    using Xunit;
    using LegalManager.Models.Entities.Finance;
    using LegalManager.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class FinancesControllerTests
    {
        private FinancesController _testClass;
        private ApplicationDbContext _context;

        public FinancesControllerTests()
        {
            _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            _testClass = new FinancesController(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new FinancesController(_context);
            
            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public async Task CannotCallCreateWithBookKeepingWithNullBookKeeping()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Create(default(BookKeeping)));
        }
    }
}