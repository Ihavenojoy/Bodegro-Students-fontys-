using Interfaces;
using DAL;
using Domain.Containers.UserFile;
using Azure.Core;
using Domain.Modules;
using Microsoft.AspNetCore.Identity;
using Domain.Containers.PatientFile;

namespace BodegroASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            _ = StartCheckingAsync();
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // DI - Container
            services.AddSingleton<UserContainer>();
            services.AddSingleton<IUser, UserDAL>();

            services.AddSingleton<PatientContainer>();
            services.AddSingleton<IPatient, PatientDAL>();

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

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=LinkDoctorToPatient}/{action=LinkDoctorToPatient}/{id?}");

            app.Run();
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
        static async Task StartCheckingAsync()
        {
            while (true)
            {
                CheckCondition();
                await Task.Delay(1000); // Check every 1 second
            }
        }

        static void CheckCondition()
        {
            //Deze method is voor het periodice verzenden van een mail naar een pati�nt naar mate van de datum
        }
    }
}
