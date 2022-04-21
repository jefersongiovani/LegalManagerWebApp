// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="ApplicationDbContext.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Models.Common;
using LegalManager.Models.Entities.Calendar;
using LegalManager.Models.Entities.Cases;
using LegalManager.Models.Entities.Clients;
using LegalManager.Models.Entities.Company;
using LegalManager.Models.Entities.Documents;
using LegalManager.Models.Entities.Finance;
using LegalManager.Models.Entities.Services;
using LegalManager.Models.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LegalManager.Models;

namespace LegalManager.Data
{
    /// <summary>
    /// Context class responsible for the persistence of the classes (entities) using
    /// Entityframework.Core
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>The addresses.</value>
        /// Entities.Common
        /// DbSet of addresses
        public virtual DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the client addresses.
        /// </summary>
        /// <value>The client addresses.</value>
        /// Class that inherits from the abstract class with additional paramenters for clients
        public virtual DbSet<ClientAddress> ClientAddresses { get; set; }

        /// <summary>
        /// Gets or sets the contact informations.
        /// </summary>
        /// <value>The contact informations.</value>
        /// DbSet of ClientContactInformation objects
        public virtual DbSet<ClientContactInformation> ContactInformations { get; set; }

        /// <summary>
        /// Gets or sets the user addresses.
        /// </summary>
        /// <value>The user addresses.</value>
        /// DbSet of UserAdress objects
        public virtual DbSet<UserAddress> UserAddresses { get; set; }


        /// <summary>
        /// Gets or sets the events.
        /// </summary>
        /// <value>The events.</value>
        /// Entities.Calendar
        /// DbSet for Event objects to be used into the calendar
        public virtual DbSet<Event> Events { get; set; }


        /// <summary>
        /// Gets or sets the cases.
        /// </summary>
        /// <value>The cases.</value>
        /// Entities.Cases
        /// DbSet of Case objects
        public virtual DbSet<Case> Cases { get; set; }

        /// <summary>
        /// Gets or sets the mediator cases.
        /// </summary>
        /// <value>The mediator cases.</value>
        /// DbSet of MediatorCase objects
        public virtual DbSet<MediatorCase> MediatorCases { get; set; }

        /// <summary>
        /// Gets or sets the clients.
        /// </summary>
        /// <value>The clients.</value>
        /// Entities.Clients.Client - DbSet for Client objects
        public virtual DbSet<Client> Clients { get; set; }


        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        /// <value>The companies.</value>
        /// Entities.Company
        /// DbSet for the Company object
        public virtual DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets the company informations.
        /// </summary>
        /// <value>The company informations.</value>
        /// DbSet for CompanyInformation objects
        public virtual DbSet<CompanyInformation> CompanyInformations { get; set; }

        /// <summary>
        /// Gets or sets the locations.
        /// </summary>
        /// <value>The locations.</value>
        /// Entity.Documents
        /// DbSet for Document Locations
        public virtual DbSet<Location> Locations { get; set; }

        /// <summary>
        /// Gets or sets the document bases.
        /// </summary>
        /// <value>The document bases.</value>
        /// DbSet for Documents
        public virtual DbSet<DocumentBase> DocumentBases { get; set; }

        /// <summary>
        /// Gets or sets the document lables.
        /// </summary>
        /// <value>The document lables.</value>
        public virtual DbSet<DocumentLable> DocumentLables { get; set; }


        /// <summary>
        /// Gets or sets the bank accounts.
        /// </summary>
        /// <value>The bank accounts.</value>
        /// Finance
        /// DbSet for Bank Accounts
        public virtual DbSet<BankAccount> BankAccounts { get; set; }

        /// <summary>
        /// Gets or sets the book keepings.
        /// </summary>
        /// <value>The book keepings.</value>
        /// DbSet for Bookkeeping
        public virtual DbSet<BookKeeping> BookKeepings { get; set; }

        /// <summary>
        /// Gets or sets the expenses.
        /// </summary>
        /// <value>The expenses.</value>
        /// DbSet for Expenses
        public virtual DbSet<Expenses> Expenses { get; set; }

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        /// <value>The invoices.</value>
        /// DbSet for Invoices
        public virtual DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// Gets or sets the instalments.
        /// </summary>
        /// <value>The instalments.</value>
        /// DbSet for Instalments
        public virtual DbSet<InvoiceInstalments> Instalments { get; set; }

        /// <summary>
        /// Gets or sets the petit cash.
        /// </summary>
        /// <value>The petit cash.</value>
        /// DbSet for Petit Cash
        public virtual DbSet<PetitCash> PetitCash { get; set; }


        /// <summary>
        /// Gets or sets the chosen services.
        /// </summary>
        /// <value>The chosen services.</value>
        /// Services (from the company)
        /// DbSet for Services provided by the company other than legal services
        public virtual DbSet<ChosenService> ChosenServices { get; set; }


        /// <summary>
        /// Gets or sets the application users.
        /// </summary>
        /// <value>The application users.</value>
        /// Users
        /// DbSet for Applicationn User
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }

        /// <summary>
        /// Gets or sets the user titles.
        /// </summary>
        /// <value>The user titles.</value>
        /// DbSet for User titles
        public virtual DbSet<UserTitle> UserTitles { get; set; }

        /// <summary>
        /// Gets or sets the digital signatures.
        /// </summary>
        /// <value>The digital signatures.</value>
        /// DbSet for Signature code
        public virtual DbSet<DigitalSignature> DigitalSignatures { get; set; }


        /// <inheritdoc />

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            ///Renaming Identity Tables
            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            

            ///Defining the MaxLength property to work with MySQL

            
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail).HasMaxLength(255));
            modelBuilder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName).HasMaxLength(255));


            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName).HasMaxLength(200));
            modelBuilder.Entity<IdentityRole>(entity => entity.Property(m => m.Id).HasMaxLength(200));


            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey).HasMaxLength(200));


            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));


            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider).HasMaxLength(200));
            modelBuilder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name).HasMaxLength(200));

            modelBuilder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId).HasMaxLength(200));
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId).HasMaxLength(200));

            ///Seeding data


            ///Data for the payment methods
            modelBuilder.Entity<PaymentMethods>().HasData(
                //Common data for PaymentMethods
                new PaymentMethods { Id = 1, Name = "Bank Transfer" },
                new PaymentMethods { Id = 2, Name = "Debit Card" },
                new PaymentMethods { Id = 3, Name = "Cash" },
                new PaymentMethods { Id = 4, Name = "Credit Card" }

                );

            ///Adding default user for the new installed application
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "e66c4e0d-6509-4625-85f7-57625a065059",
                    FirstName = "Administrator",
                    LastName = "Clerk",
                    UserStatus = true,
                    UserName = "administrator@clerk.com",
                    NormalizedUserName = "ADMINISTRATOR@CLERK.COM",
                    Email = "administrator@clerk.com",
                    NormalizedEmail = "ADMINISTRATOR@CLERK.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEP54Z3UAUXVDQkTWjsPnmlTJojkcspW6qtfQesB3s/fgaJXQ48Lwc/DZpmXx5D3zHg==",
                    SecurityStamp = "NAAWA2T3E3FYUKYAM34CWKW5HLWDVTPX",
                    ConcurrencyStamp = "f141ec91-b528-4c6e-9f47-f9c0eeacfbf2",
                    PhoneNumber = "07957000000",
                    PhoneNumberConfirmed = false,
                    TwoFactorEnabled = false,
                    LockoutEnabled = true,
                    AccessFailedCount = 0


                });


            ///Data for the default roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "dd251d39-91c5-4277-a106-6bb7193d6980", Name = "Administrator", NormalizedName = "ADMINISTRATOR", ConcurrencyStamp = "533b7cf5-8619-4ca4-a880-5757eab9d9a0" },
                new IdentityRole { Id = "fe2b7852-67e4-4672-9c2e-1c7bd022d28b", Name = "Basic", NormalizedName = "BASIC", ConcurrencyStamp = "32b6d30b-1d7a-4695-b52a-49ba09a72504" },
                new IdentityRole { Id = "9926236b-ae6b-4387-b717-6e3100b9c920", Name = "BookKeeper", NormalizedName = "BOOKKEEPER", ConcurrencyStamp = "4baf03e5-ab51-4bb4-a92a-27ac6f85157e" },
                new IdentityRole { Id = "08d6dcfd-731a-40fd-9773-3160c5de252b", Name = "LegalAssistant", NormalizedName = "LEGALASSISTANT", ConcurrencyStamp = "786c7f12-085e-4027-8975-83f135c6c2f7" },
                new IdentityRole { Id = "f80a6846-06d5-4df6-8630-da40d9eced4e", Name = "Manager", NormalizedName = "MANAGER", ConcurrencyStamp = "c917f812-a879-496d-90a8-d2d2605e1a88" },
                new IdentityRole { Id = "ddecea27-3847-4fe6-8128-4b5f9ce26e21", Name = "Mediator", NormalizedName = "MEDIATOR", ConcurrencyStamp = "599f0deb-fc3d-4719-ad74-8b2be08a4264" },
                new IdentityRole { Id = "49e2d78b-4e20-4281-9256-ee579c94e851", Name = "OfficeClerk", NormalizedName = "OFFICECLERK", ConcurrencyStamp = "69d4d5da-25be-4c39-862c-5118d4fb8891" },
                new IdentityRole { Id = "f87ffea2-ef01-4f0b-a600-fad2fedaf01c", Name = "OISC", NormalizedName = "OISC", ConcurrencyStamp = "a184011a-e2e6-4ccf-b33c-dc3e0af9e106" },
                new IdentityRole { Id = "e837ff9a-2887-4615-9e7f-682e210a8776", Name = "Paralegal", NormalizedName = "PARALEGAL", ConcurrencyStamp = "fd6e383e-226b-4eb5-a57e-770d19e21430" },
                new IdentityRole { Id = "e63eaefa-b668-4ca1-81fe-e115cf5121ee", Name = "Solicitor", NormalizedName = "SOLICITOR", ConcurrencyStamp = "f6a62d13-c36f-4171-81d7-6ce6b2f1d0ad" }
                );
        }


        /// <summary>
        /// Gets or sets the collegue view model.
        /// </summary>
        /// <value>The collegue view model.</value>
        /// Rebuilding the name of the User entity to ApplicationUser, and Other tables

        public DbSet<LegalManager.Models.CollegueViewModel> CollegueViewModel { get; set; }


    }
}
