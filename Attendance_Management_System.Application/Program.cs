using Microsoft.EntityFrameworkCore;
using Attendance_Management_System.Infrastructure.Data;
using Microsoft.Extensions.Options;
using Attendance_Management_System.Infrastructure.Repositories;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace Attendance_Management_System.Application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // CORS
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("MyPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            // SQL Connection Establish
            //builder.Services.AddDbContext<ApplicationDbContext>(option =>
            //{
            //    option.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnStr"));

            //});
            // SQL Connection Establish
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                // Configure the connection string for your database
                var configuration = builder.Configuration;
                var connectionString = configuration.GetConnectionString("SqlServerConnStr");
                options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("Attendance_Management_System.Application"));
            });






            // Repositories
            builder.Services.AddScoped<EmployeeRepository>();
            builder.Services.AddScoped<ApplicationDbContext>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                // Apply migrations in Development environment
                using (var scope = app.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var dbContext = services.GetRequiredService<ApplicationDbContext>();
                    dbContext.Database.Migrate(); // Apply pending migrations
                }
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("MyPolicy");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}