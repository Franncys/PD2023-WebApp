using Microsoft.EntityFrameworkCore;
using WebAppNarutoDB.Models;

namespace WebAppNarutoDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string mySqlConnectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
            //Register services here
            builder.Services.AddDbContext<NarutoDbContext>(options => options.UseMySql(
                mySqlConnectionStr,
                ServerVersion.AutoDetect(mySqlConnectionStr)
            ));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
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