
using EmployeeApp.DAL.Context;
using EmployeeApp.DAL.Infrastructure;
using EmployeeApp.DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Employee_CRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

   


            #region Injection Dependence Configuration

            // Register EmployeeRepo Repositories
            builder.Services.AddScoped<IEmpolyeeRepo, EmpolyeeRepo>();

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

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
