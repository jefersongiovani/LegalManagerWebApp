namespace LegalManagerUnitTests.Areas.Administrative.Controllers
{
    using LegalManager.Areas.Administrative.Controllers;
    using System;
    using Xunit;
    using LegalManager.Models.Entities.Clients;
    using LegalManager.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class ClientsControllerTests
    {
        private ClientsController _testClass;
        private ApplicationDbContext _context;

        public ClientsControllerTests()
        {
            _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            _testClass = new ClientsController(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ClientsController(_context);
            
            // Assert
            Assert.NotNull(instance);
        }

      
        [Fact]
        public async Task CannotCallCreateWithClientWithNullClient()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Create(default(Client)));
        }

      
    }
}