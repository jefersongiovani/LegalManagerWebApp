namespace LegalManagerUnitTests.Api
{
    using LegalManager.Api;
    using System;
    using Xunit;
    using NSubstitute;
    using System.Collections.Generic;
    using LegalManager.Models;
    using Microsoft.AspNetCore.Identity;
    using LegalManager.Models.Entities.Users;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Logging;
    using System.Threading.Tasks;

    public class UserRolesControllerTests
    {
        private UserRolesController _testClass;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserRolesControllerTests()
        {
            _userManager = new UserManager<ApplicationUser>(Substitute.For<IUserStore<ApplicationUser>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<IPasswordHasher<ApplicationUser>>(), new[] { Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>() }, new[] { Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>() }, Substitute.For<ILookupNormalizer>(), new IdentityErrorDescriber(), Substitute.For<IServiceProvider>(), Substitute.For<ILogger<UserManager<ApplicationUser>>>());
            _roleManager = new RoleManager<IdentityRole>(Substitute.For<IRoleStore<IdentityRole>>(), new[] { Substitute.For<IRoleValidator<IdentityRole>>(), Substitute.For<IRoleValidator<IdentityRole>>(), Substitute.For<IRoleValidator<IdentityRole>>() }, Substitute.For<ILookupNormalizer>(), new IdentityErrorDescriber(), Substitute.For<ILogger<RoleManager<IdentityRole>>>());
            _testClass = new UserRolesController(_userManager, _roleManager);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UserRolesController(_userManager, _roleManager);
            
            // Assert
            Assert.NotNull(instance);
        }
    }
}