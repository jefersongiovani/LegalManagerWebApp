namespace LegalManagerUnitTests.Api
{
    using LegalManager.Api;
    using System;
    using Xunit;
    using NSubstitute;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class RoleManagerControllerTests
    {
        private RoleManagerController _testClass;
        private RoleManager<IdentityRole> _roleManager;

        public RoleManagerControllerTests()
        {
            _roleManager = new RoleManager<IdentityRole>(Substitute.For<IRoleStore<IdentityRole>>(), new[] { Substitute.For<IRoleValidator<IdentityRole>>(), Substitute.For<IRoleValidator<IdentityRole>>(), Substitute.For<IRoleValidator<IdentityRole>>() }, Substitute.For<ILookupNormalizer>(), new IdentityErrorDescriber(), Substitute.For<ILogger<RoleManager<IdentityRole>>>());
            _testClass = new RoleManagerController(_roleManager);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new RoleManagerController(_roleManager);
            
            // Assert
            Assert.NotNull(instance);
        }
    }
}