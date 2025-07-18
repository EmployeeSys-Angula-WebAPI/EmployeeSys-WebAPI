using EmployeeApp.Domain;

namespace EmpolyeeApp.business.Contracts
{
    public interface IEmolyeeManager
    {
        public Task<IReadOnlyList<Employee>> GetAllEmployeesAsync();
        public Task<Employee> CreateEmpAsync(Employee entity);
        public Task<bool> DeleteAsync(int id);
        public Task<Employee?> GetEmployeeIdAsync(int id);
        public Task<Employee> UpdatedAsync(Employee entity);
    }
}
