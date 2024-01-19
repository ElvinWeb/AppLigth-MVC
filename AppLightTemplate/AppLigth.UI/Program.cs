using AppLight.Business;
using AppLight.Core.Entities;
using AppLight.Data;
using AppLight.Data.DAL;
using AppLigth.UI.ViewService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AppLigth.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<LayoutService>();
            builder.Services.ServicesRegister();
            builder.Services.RepositoriesRegister();
            builder.Services.AddDbContext<ProjectDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("myDb1"));
            });
            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;

                options.User.RequireUniqueEmail = false;

            }).AddEntityFrameworkStores<ProjectDbContext>().AddDefaultTokenProviders();
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
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllerRoute(
                     name: "areas",
                     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.Run();
        }
    }
}