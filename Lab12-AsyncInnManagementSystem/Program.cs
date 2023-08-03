namespace Lab12_AsyncInnManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            //Add services  to the container
            builder.Services.AddControllersWithViews();

            //create data context
            /*
            builder.Services.AddDbContext<AsyncInnContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                    .GetConnectionString("DefaultConnection")));
            */

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