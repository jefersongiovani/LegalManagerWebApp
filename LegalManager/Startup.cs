// ***********************************************************************
// Assembly         : LegalManager
// Author           : jefersongiovanischne
// Created          : 04-09-2022
//
// Last Modified By : jefersongiovanischne
// Last Modified On : 04-09-2022
// ***********************************************************************
// <copyright file="Startup.cs" company="LegalManager">
//     2022
// </copyright>
// <summary></summary>
// ***********************************************************************
using LegalManager.Data;
using LegalManager.Models.Entities.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace LegalManager
{
    /// <summary>
    /// Class Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Setting the Database type and connection string
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySQL(
                Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDatabaseDeveloperPageExceptionFilter();

            //Setting the Individual User Authentication (IdentityUser) and the Role based access
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();
            services.AddAuthorization(options =>
            {
                ///Creating the policies for the users
                ///Administrative
                options.AddPolicy("AdministrativeRights", policy =>
                    policy.RequireRole("Administrator", "Owner"));

                ///Policies for Legal Advisers
                ///
                options.AddPolicy("LegalAccess", policy =>
                    policy.RequireRole("Solicitor", "OISC", "Mediator", "Paralegal", "LegalAssistant"));

                ///Policy for specific Legal Advisers
                ///
                options.AddPolicy("MediatorAccess", policy =>
                   policy.RequireRole("Mediator"));
                options.AddPolicy("ImmigrationAccess", policy =>
                   policy.RequireRole("OISC", "Solicitor"));

                ///Policy for Managers and specific areas
                ///
                options.AddPolicy("ManagerAccess", policy =>
                    policy.RequireRole("BookKeeper", "Manager"));

                ///Basic Access for employees
                options.AddPolicy("EmployeeAccess", policy =>
                    policy.RequireRole("OfficeClerk"));
                options.AddPolicy("BasicAccess", policy =>
                    policy.RequireRole("Basic"));

                /// Policy for the entire system.To access the system the user needs to be logged in

                options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            });
            services.AddAntiforgery(options =>
                options.HeaderName = "LEGALMANAGERAPP-XSRF-TOKEN");

            /// Enabling Compression for HTTP responses
            services.AddResponseCaching();
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.MimeTypes = new[] { "text/plain", "text/css",
                                            "application/javascript",
                                            "text/html",
                                            "application/xml",
                                            "text/xml",
                                            "application/json",
                                            "text/json" };
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
 

        }

        /// <summary>
        /// Configures the aspects of the application that are initialised and the hosting environment.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                /// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = content =>
                {
                    if (content.File.Name.EndsWith(".js.gz"))
                    {
                        content.Context.Response.Headers["Content-Type"] = "text/javascript";
                        content.Context.Response.Headers["Content-Encoding"] = "gzip";
                    }
                }
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                ///Setting up the endpoints
                ///
                endpoints.MapAreaControllerRoute(
                    name: "Administrative",
                    areaName: "Administrative",
                    pattern: "Administrative/{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller}/{action}/{id?}"
                    );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
                endpoints.MapControllerRoute(
                    name: "Api",
                    pattern: "Api/{controller=Home}/{action=Index}/{id?}"
                    );

                endpoints.MapRazorPages();
            });


        }
    }
}
