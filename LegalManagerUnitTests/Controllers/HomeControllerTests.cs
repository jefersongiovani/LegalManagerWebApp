namespace LegalManagerUnitTests.Api
{
    using LegalManager.Api;
    using System;
    using Xunit;
    using NSubstitute;
    using Microsoft.Extensions.Logging;

    public class HomeControllerTests
    {
        private HomeController _testClass;
        private ILogger<HomeController> _logger;

        public HomeControllerTests()
        {
            _logger = Substitute.For<ILogger<HomeController>>();
            _testClass = new HomeController(_logger);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new HomeController(_logger);
            
            // Assert
            Assert.NotNull(instance);
        }
    }
}