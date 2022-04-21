namespace LegalManagerUnitTests.Api
{
    using LegalManager.Api;
    using System;
    using Xunit;
    using NSubstitute;
    using LegalManager.Models.Entities.Cases;
    using LegalManager.Models.Entities.Documents;
    using Microsoft.AspNetCore.Identity;
    using LegalManager.Models.Entities.Users;
    using Microsoft.Extensions.Options;
    using System.Collections.Generic;
    using Microsoft.Extensions.Logging;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Authentication;
    using LegalManager.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using LegalManager.Controllers;

    public class DocumentControllerTests
    {
        private DocumentController _testClass;
        private SignInManager<ApplicationUser> _signInManager;
        private ILogger<DocumentBase> _logger;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _context;

        public DocumentControllerTests()
        {
            _signInManager = new SignInManager<ApplicationUser>(new UserManager<ApplicationUser>(Substitute.For<IUserStore<ApplicationUser>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<IPasswordHasher<ApplicationUser>>(), new[] { Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>() }, new[] { Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>() }, Substitute.For<ILookupNormalizer>(), new IdentityErrorDescriber(), Substitute.For<IServiceProvider>(), Substitute.For<ILogger<UserManager<ApplicationUser>>>()), Substitute.For<IHttpContextAccessor>(), Substitute.For<IUserClaimsPrincipalFactory<ApplicationUser>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<ILogger<SignInManager<ApplicationUser>>>(), Substitute.For<IAuthenticationSchemeProvider>(), Substitute.For<IUserConfirmation<ApplicationUser>>());
            _logger = Substitute.For<ILogger<DocumentBase>>();
            _userManager = new UserManager<ApplicationUser>(Substitute.For<IUserStore<ApplicationUser>>(), Substitute.For<IOptions<IdentityOptions>>(), Substitute.For<IPasswordHasher<ApplicationUser>>(), new[] { Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>(), Substitute.For<IUserValidator<ApplicationUser>>() }, new[] { Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>(), Substitute.For<IPasswordValidator<ApplicationUser>>() }, Substitute.For<ILookupNormalizer>(), new IdentityErrorDescriber(), Substitute.For<IServiceProvider>(), Substitute.For<ILogger<UserManager<ApplicationUser>>>());
            _context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());
            _testClass = new DocumentController(_signInManager, _logger, _userManager, _context);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new DocumentController(_signInManager, _logger, _userManager, _context);
            
            // Assert
            Assert.NotNull(instance);
        }
    }
}