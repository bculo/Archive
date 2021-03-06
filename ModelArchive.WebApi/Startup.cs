using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ModelArchive.Application;
using ModelArchive.Application.Behaviours;
using ModelArchive.Application.Config;
using ModelArchive.Application.Contracts;
using ModelArchive.Application.Contracts.Repositories;
using ModelArchive.Common;
using ModelArchive.Infrastracture.Services;
using ModelArchive.Persistence;
using ModelArchive.Persistence.Identity;
using ModelArchive.Persistence.Repositories;
using ModelArchive.WebApi.Filters;
using ModelArchive.WebApi.Services;
using System;
using System.Globalization;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

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
            services.AddLocalization();

            //Globalization and localization setup
            var languages = Configuration.GetSection("LanguageOptions").Get<LanguageOptions>();
            CultureInfo[] supportedCultures = new CultureInfo[languages.Languages.Length];
            foreach (var (lan, index) in languages.Languages.WithIndex())
                supportedCultures[index] = new CultureInfo(lan);

            string defaultLan = languages.DefaultLanguage;
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: defaultLan, uiCulture: defaultLan);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            //options sections
            services.AddOptions();
            services.Configure<AuthenticationOptions>(Configuration.GetSection(nameof(AuthenticationOptions)));
            services.Configure<LanguageOptions>(Configuration.GetSection(nameof(LanguageOptions)));
            services.Configure<RoleOptions>(Configuration.GetSection(nameof(RoleOptions)));

            //Define database
            services.AddDbContext<ArchiveDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ModelArchive"))
            );

            //Data Protection
            services.AddDataProtection()
                .SetApplicationName("model-archive");

            //add identity
            //services.AddIdentity<AuthenticationUser, IdentityRole<Guid>>()
            services.AddIdentityCore<AuthenticationUser>()
                .AddRoles<AuthenticationRole>()
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
            services.AddAuthentication()
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                {
                    options.Cookie.HttpOnly = identity.Cookie.HttpOnly;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(identity.Cookie.ExpireTimeSpan);
                    options.SlidingExpiration = identity.Cookie.SlidingExpiration;
                    options.LoginPath = string.Empty;
                    options.AccessDeniedPath = string.Empty;
                    options.Events.OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api"))
                        {
                            ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        }

                        return Task.CompletedTask;
                    };
                });

            //Defaine authorizaion Default policy
            services.AddAuthorization(configure =>
            {
                configure.DefaultPolicy =
                    new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddAuthenticationSchemes(new[] 
                    { 
                        CookieAuthenticationDefaults.AuthenticationScheme 
                    })
                    .Build();
            });
            
            //For HttpContext access
            services.AddHttpContextAccessor();

            //DI
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IDatabaseTransaction, DatabaseTransaction>();
            services.AddTransient(typeof(ITransaction<>), typeof(Transaction<>));

            services.AddScoped<IAuthService, HttpContextAuthService>();
            services.AddScoped<ICurrentUser, CurrentUserService>();

            services.AddScoped<IUserRepository, UserRepository>();

            //MediatR
            services.AddMediatR(typeof(AssemblyResource).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ExceptionBehavior<,>));

            //add fluent validation
            services.AddControllers(opt =>
            {
                opt.Filters.Add<ArchiveExceptionFilter>(); //Exception filter registration
            });

            //fluent validation
            services.AddValidatorsFromAssembly(typeof(AssemblyResource).Assembly);

            /*
            .AddFluentValidation(opt => 
            { 
                opt.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                //opt.RegisterValidatorsFromAssembly(typeof(AssemblyResource).Assembly);
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization();

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
