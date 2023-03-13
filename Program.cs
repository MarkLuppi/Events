using Event.Services;
using Events.DbContexts;
using Events.Services;
using Microsoft.EntityFrameworkCore;

namespace Events
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddCors();

            builder.Services.AddControllers();

            builder.Services.AddDbContext<EventInfoContext>(
                dbContextOptions => dbContextOptions.UseSqlServer(
                    // get connection string from unsecured appSettings for Development context
                    builder.Configuration.GetConnectionString("EventInfoDBConnectionString")
                    )
                );
            builder.Services.AddScoped<IEventInfoRepository, EventInfoRepository>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
          
            app.UseRouting();
            app.UseCors(x => x.SetIsOriginAllowed(origin => true));
            app.UseStaticFiles();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}