using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestWeb.Data;
using TestWeb.Repository.implementation;
using TestWeb.Repository.Interface;
using TestWeb.Repostory.Base;
using TestWeb.Services;
using TestWeb.Services.implementation;
using TestWeb.Services.Interface;
using TestWeb.SharedRepositories.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using TestWeb.Services.Email;

namespace TestWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // hna ana bolh ya server a3mly concet m3a data base sql sever by conction string dh 
            builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("MyConnection")
                ));

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
              .AddRoles<IdentityRole>()
                 .AddEntityFrameworkStores<AppDbContext>();

           
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddServices();
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //hna hwa  by3ml midelwar yt2kd ale awl hwa fe mr7lt ale deve wla l2
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
                name: "Area",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoint=>endpoint.MapRazorPages());
            app.Run();
        }
    }
}
