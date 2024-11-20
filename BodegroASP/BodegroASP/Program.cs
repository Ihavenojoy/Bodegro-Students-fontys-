using Interfaces;
using DAL;
using Domain.Containers.UserFile;

namespace BodegroASP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // DI - Container
            services.AddSingleton<UserContainer>();

            // DI - Interface, implementation
            services.AddSingleton<IUser, UserDAL>();

            builder.Services.AddTransient<PatientDAL>();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
