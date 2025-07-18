using EmployeeApp.DAL.Context;
using EmployeeApp.DAL.Extensions;
using EmployeeApp.DAL.Infrastructure;
using EmployeeApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.DAL.Repositories;

public class EmpolyeeRepo(ApplicationDbContext context) : IEmpolyeeRepo
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Employee> CreateEmpAsync(Employee entity)
    {
        var existingEmployee = await _context.Employees
       .FirstOrDefaultAsync(e => e.Email == entity.Email);

        if (existingEmployee is not null)
        {
            return existingEmployee;
        }
        await _context.Employees.AddAsync(entity);
        await SavaChange();

        return entity;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Employees.FindAsync(id);
        if (entity is not null)
        {
            _context.Employees.Remove(entity);
            await SavaChange();
            return true;
        }
        return false;
    }

    public async Task<IReadOnlyList<Employee>> GetAllEmployeesAsync() => await _context.Employees.ToListAsync();  
  

    public async Task<Employee?> GetEmployeeIdAsync(int id) =>  await _context.Employees.FindAsync(id); 

    public async Task SavaChange() => await _context.SaveChangesAsync();


    public async Task<Employee> UpdatedAsync(Employee entity)
    {
        var existingEmployee = await _context.Employees.FindAsync(entity.Id);

        if (existingEmployee == null)
        {
            throw new Exception("Employee not found");
        }

        existingEmployee.UpdateWith(entity);

        _context.Employees.Update(existingEmployee);
        await SavaChange();

        return existingEmployee;

    }
}
