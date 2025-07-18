using EmployeeApp.Domain;


namespace EmpolyeeApp.business.Contracts
{
    public interface IEmployeeManager
    {
        public Task<IReadOnlyList<EmpDTO>> GetAllEmployeesAsync();
        public Task<EmpDTO> CreateEmpAsync(EmpDTO entity);
        public Task<bool> DeleteAsync(int id);
        public Task<EmpDTO?> GetEmployeeIdAsync(int id);
        public Task<EmpDTO> UpdatedAsync(EmpDTO entity);
        public Task<List<EmpDTO>> FuzzySearchEmployeesAsync(string name);
        Task<bool> ExistsAsync(int id);
    }
}
