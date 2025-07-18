using EmployeeApp.Domain;

namespace EmployeeApp.DAL.Context;

public static class ApplicationDbContextSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!context.Employees.Any())
        {
            var employees = new List<Employee>
            {
                new() { FirstName = "Rawan", LastName = "Qandel", Email = "rawan@example.com", Position = ".NET Developer" },
                new() { FirstName = "Ali", LastName = "Hassan", Email = "ali@example.com", Position = "Backend Developer" },
                new() { FirstName = "Nour", LastName = "Ahmed", Email = "nour@example.com", Position = "Frontend Developer" },
                new() { FirstName = "Salma", LastName = "Mohamed", Email = "salma@example.com", Position = "UI/UX Designer" },
                new() { FirstName = "Omar", LastName = "Khaled", Email = "omar@example.com", Position = "Mobile Developer" },
                new() { FirstName = "Mona", LastName = "Adel", Email = "mona@example.com", Position = "QA Engineer" },
                new() { FirstName = "Kareem", LastName = "Nabil", Email = "kareem@example.com", Position = "DevOps Engineer" },
                new() { FirstName = "Sara", LastName = "Youssef", Email = "sara@example.com", Position = "Project Manager" },
                new() { FirstName = "Mahmoud", LastName = "Hany", Email = "mahmoud@example.com", Position = "Security Analyst" },
                new() { FirstName = "Layla", LastName = "Fouad", Email = "layla@example.com", Position = "Product Owner" },
            };

            context.Employees.AddRange(employees);
            await context.SaveChangesAsync();
        }
    }
}
