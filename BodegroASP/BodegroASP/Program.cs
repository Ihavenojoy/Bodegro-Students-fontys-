using Azure;
using BodegroASP.BackGroundServices;
using BodegroASP.BackGroundServices.MailTask;
using BodegroASP.BackGroundServices.TwoFactorTask;
using DAL;
using DAL.DAL_s;
using Domain.Containers.PatientFile;
using Domain.Containers.SubscriptionFile;
using Domain.Containers.TwoFactorFile;
using Domain.Containers.UserFile;
using Domain.Modules;
using Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Web;
using Twofactor;


namespace BodegroASP
{
    public class Program
    {
        static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            ConfigureServices();
            var logger = _serviceProvider.GetService<ILogger<MailBackGroundService>>();
            var mailBackGroundService = new MailBackGroundService(_serviceProvider, logger);
            Task.Run(() => mailBackGroundService.StartAsync(CancellationToken.None));
            var TwoFactorService = new TwoFactorDone();
            Task.Run(() => TwoFactorService.ValidTwoFactorCheck());
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;


            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IUser, UserDAL>();
            builder.Services.AddScoped<IRequest, RequestDAL>();
            builder.Services.AddScoped<ITwoFactor, TwoFactorDAL>();
            builder.Services.AddScoped<UserContainer>();
            builder.Services.AddScoped<TwoFactorContainer>();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20); // Session timeout
                options.Cookie.HttpOnly = true;                // Secure session cookies
                options.Cookie.IsEssential = true;             // Ensure cookies are GDPR compliant
            });

            // DI - Container
            services.AddSingleton<UserContainer>();
            services.AddSingleton<IUser, UserDAL>();

            services.AddSingleton<PatientContainer>();
            services.AddSingleton<IPatient, PatientDAL>();

            services.AddSingleton<TwoFactorContainer>();
            services.AddSingleton<ITwoFactor, TwoFactorDAL>();

            // Setting up the authentication scheme
            builder.Services.AddAuthentication("CookieAuth")
                .AddCookie("CookieAuth", options =>
                {
                    options.LoginPath = "/Account/LogIn";
                    options.AccessDeniedPath = "/Account/AccessDenied";
                    options.Cookie.Name = "YourAppName.AuthCookie";
                });


            // Add appsettings.json to the configuration
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=LogIn}/{id?}");

            app.Run();
        }
        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddLogging(config => config.AddConsole());
            services.AddScoped<ISubscriptionCheckerService, SubscriptionCheckerService>();
            services.AddScoped<ISubscriptionContainer, SubscriptionContainer>();
            services.AddScoped<ISubscription, SubscriptionDAL>();
            services.AddScoped<SubscriptionDAL>();
            services.AddHostedService<MailBackGroundService>();
            _serviceProvider = services.BuildServiceProvider();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            // Add session services
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout as per your needs
                options.Cookie.HttpOnly = true; // Set cookies to be HttpOnly for security
                options.Cookie.IsEssential = true; // Required for session to work on all browsers
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable session
            app.UseSession();

            // Other middlewares like UseRouting, UseAuthentication, etc.
        }
    }
}
