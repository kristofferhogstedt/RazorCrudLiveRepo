using Microsoft.EntityFrameworkCore;
using RazorLiveDemo.Data;

namespace RazorLiveDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // L�gg till min DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // L�gg till min DataInitializer med Dependency Injection
            builder.Services.AddTransient<DataInitializer>();

            var app = builder.Build();

            // K�r min SeedData() metod
            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetService<DataInitializer>().MigrateData();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();

            app.Run();
        }
    }
}
