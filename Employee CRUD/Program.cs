
using EmployeeApp.DAL.Context;
using EmployeeApp.DAL.Infrastructure;
using EmployeeApp.DAL.Repositories;
using EmpolyeeApp.business.Contracts;
using EmpolyeeApp.business.Managers;
using Microsoft.EntityFrameworkCore;

namespace Employee_CRUD
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Injection Dependence Configuration

            // Register EmployeeRepo Repositories
            builder.Services.AddScoped<IEmpolyeeRepo, EmpolyeeRepo>();
            builder.Services.AddScoped<IEmployeeManager, EmployeManager>();

            #endregion

            builder.Services.AddControllers();

            #region Make_connectionstring

            var ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options
                        .UseSqlServer(ConnectionString) 
                        .LogTo(Console.WriteLine, LogLevel.Warning);
                }
            );

            #endregion


            #region CORS Configuration
            builder.Services.AddCors(options =>
              {
                  options.AddPolicy("AllowFrontend",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:4200")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
              }); 
            #endregion

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            #region Database Seeding

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await ApplicationDbContextSeeder.SeedAsync(context); 
            }

            #endregion
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors("AllowFrontend");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
