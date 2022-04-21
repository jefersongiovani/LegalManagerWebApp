namespace LegalManagerUnitTests.Api
{
    using LegalManager.Api;
    using System;
    using Xunit;
    using LegalManager.Models.Entities.Finance;
    using LegalManager.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class BankAccountsControllerTests
    {
        private BankAccountsController _testClass;
        private ApplicationDbContext _context;

        public BankAccountsControllerTests()
        {
            _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            _testClass = new BankAccountsController(_context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new BankAccountsController(_context);
            
            // Assert
            Assert.NotNull(instance);
        }

    
        [Fact]
        public async Task CannotCallCreateWithBankAccountWithNullBankAccount()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.Create(default(BankAccount)));
        }
    }
}