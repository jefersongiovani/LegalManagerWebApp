namespace LegalManagerUnitTests.Api
{
    using LegalManager.Api;
    using System;
    using Xunit;
    using NSubstitute;
    using LegalManager.Models.Entities.Users;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Logging;
    using LegalManager.Areas.Identity.Pages.Account;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using LegalManager.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class UsersControllerTests
    {
        private UsersController _testClass;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ILogger<RegisterModel> _logger;
        private SignInManager<ApplicationUser> _signInManager;
        private IEmailSender _emailSender;
        private ApplicationDbContext _context;

        public UsersControllerTests()
        {
            _userManager = new UserManager<ApplicationUser>(Substitute.For<IUserStore<ApplicationUser>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<IPasswordHasher<ApplicationUser>>(), new[] { Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>() }, new[] { Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>() }, Substitute.For<ILookupNormalizer>(), new IdentityErrorDescriber(), Substitute.For<IServiceProvider>(), Substitute.For<ILogger<UserManager<ApplicationUser>>>());
            _roleManager = new RoleManager<IdentityRole>(Substitute.For<IRoleStore<IdentityRole>>(), new[] { Substitute.For<IRoleValidator<IdentityRole>>(), Substitute.For<IRoleValidator<IdentityRole>>(), Substitute.For<IRoleValidator<IdentityRole>>() }, Substitute.For<ILookupNormalizer>(), new IdentityErrorDescriber(), Substitute.For<ILogger<RoleManager<IdentityRole>>>());
            _logger = Substitute.For<ILogger<RegisterModel>>();
            _signInManager = new SignInManager<ApplicationUser>(new UserManager<ApplicationUser>(Substitute.For<IUserStore<ApplicationUser>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<IPasswordHasher<ApplicationUser>>(), new[] { Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>() }, new[] { Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>() }, Substitute.For<ILookupNormalizer>(), new IdentityErrorDescriber(), Substitute.For<IServiceProvider>(), Substitute.For<ILogger<UserManager<ApplicationUser>>>()), Substitute.For<IHttpContextAccessor>(), Substitute.For<IUserClaimsPrincipalFactory<ApplicationUser>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<ILogger<SignInManager<ApplicationUser>>>(), Substitute.For<IAuthenticationSchemeProvider>(), Substitute.For<IUserConfirmation<ApplicationUser>>());
            _emailSender = Substitute.For<IEmailSender>();
            _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            _testClass = new UsersController(_userManager, _roleManager, _logger, _signInManager, _emailSender, _context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new UsersController(_userManager, _roleManager, _logger, _signInManager, _emailSender, _context);
            
            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CanSetAndGetInput()
        {
            // Arrange
            var testValue = new UsersController.InputModel { FirstName = "TestValue842160974", LastName = "TestValue1006086564", Email = "TestValue2039685981", Password = "TestValue1207887547", ConfirmPassword = "TestValue915306830" };
            
            // Act
            _testClass.Input = testValue;
            
            // Assert
            Assert.Same(testValue, _testClass.Input);
        }

        [Fact]
        public void CanSetAndGetReturnUrl()
        {
            // Arrange
            var testValue = "TestValue1321274821";
            
            // Act
            _testClass.ReturnUrl = testValue;
            
            // Assert
            Assert.Equal(testValue, _testClass.ReturnUrl);
        }
    }
}