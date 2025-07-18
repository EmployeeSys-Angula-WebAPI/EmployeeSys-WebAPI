using EmployeeApp.Domain;

namespace EmpolyeeApp.business.Contracts
{
    public interface IEmployeeManager
    {
        public Task<IReadOnlyList<Employee>> GetAllEmployeesAsync();
        public Task<Employee> CreateEmpAsync(Employee entity);
        public Task<bool> DeleteAsync(int id);
        public Task<Employee?> GetEmployeeIdAsync(int id);
        public Task<Employee> UpdatedAsync(Employee entity);
        public Task<List<Employee>> FuzzySearchEmployeesAsync(string name);
    }
}
