using EmployeeApp.Domain;

namespace EmployeeApp.DAL.Infrastructure;

public interface IEmpolyeeRepo
{
    Task<Employee> CreateEmpAsync(Employee entity);
    Task<bool> DeleteAsync(int id);
    Task<Employee?> GetEmployeeIdAsync(int id);
    Task<IReadOnlyList<Employee>> GetAllEmployeesAsync();
    Task<Employee> UpdatedAsync(Employee entity);
    Task SavaChange();
}
