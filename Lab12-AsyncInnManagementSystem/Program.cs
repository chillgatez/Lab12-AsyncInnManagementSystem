using Lab12_AsyncInnManagementSystem.Data;
using Lab12_AsyncInnManagementSystem.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Lab12_AsyncInnManagementSystem.Models.Services;

namespace Lab12_AsyncInnManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            //Add services  to the container
            builder.Services.AddControllersWithViews();

            //create database context
            builder.Services.AddDbContext<AsyncInnContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                    .GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<IHotel, HotelService>();

            builder.Services.AddTransient<IRoom, RoomService>();

            builder.Services.AddTransient<IAmenity, AmenityService>();

            var app = builder.Build();

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