using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ModelArchive.Application.Behaviours;
using ModelArchive.Application.Config;
using ModelArchive.Application.Contracts;
using ModelArchive.Common;
using ModelArchive.Infrastracture.Services;
using ModelArchive.Persistence;
using System;
using System.Linq;

namespace ModelArchive.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Globalization and localization setup
            var supportedCultures = new[] { "en-US" };
            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture(supportedCultures.First());
                options.AddSupportedCultures(supportedCultures);
                var test = options.RequestCultureProviders;
            });

            //options sections
            services.AddOptions();
            services.Configure<AuthenticationOptions>(Configuration.GetSection(nameof(AuthenticationOptions)));
            
            //Define database
            services.AddDbContext<ArchiveDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ModelArchive"))
            );

            //add identity
            services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>()
                .AddErrorDescriber<MultilanguageIdentityErrorDescriber>()
                .AddEntityFrameworkStores<ArchiveDbContext>();

            //configure user attributes, password attributes and lockout attributes
            var identity = Configuration.GetSection("AuthenticationOptions").Get<AuthenticationOptions>();
            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = identity.SignIn.RequireConfirmedEmail;

                options.Password.RequireDigit = identity.Password.RequireDigit;
                options.Password.RequireLowercase = identity.Password.RequireLowercase;
                options.Password.RequiredUniqueChars = identity.Password.RequiredUniqueChars;
                options.Password.RequiredLength = identity.Password.RequiredLength;
                options.Password.RequireUppercase = identity.Password.RequireUppercase;
                options.Password.RequireNonAlphanumeric = identity.Password.RequireNonAlphanumeric;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identity.Lockout.DefaultLockoutTimeSpan);
                options.Lockout.MaxFailedAccessAttempts = identity.Lockout.MaxFailedAccessAttempts;
                options.Lockout.AllowedForNewUsers = identity.Lockout.AllowedForNewUsers;

                options.User.AllowedUserNameCharacters = identity.User.AllowedUserNameCharacters;
                options.User.RequireUniqueEmail = identity.User.RequireUniqueEmail;
            });

            //Define authentication method
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.HttpOnly = identity.Cookie.HttpOnly;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(identity.Cookie.ExpireTimeSpan);
                    options.SlidingExpiration = identity.Cookie.SlidingExpiration;
                });

            //DI
            services.AddTransient<IDateTime, DateTimeService>();
             
            services.AddScoped<IAuthService, IdentityAuthService>();

            //MediatR
            services.AddMediatR(typeof(MediatRRegistration).Assembly);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); 
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
