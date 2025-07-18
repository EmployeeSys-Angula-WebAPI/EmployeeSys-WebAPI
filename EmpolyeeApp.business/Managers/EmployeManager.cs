using EmployeeApp.DAL.Infrastructure;
using EmployeeApp.Domain;
using EmpolyeeApp.business.Contracts;
using Microsoft.EntityFrameworkCore;


namespace EmpolyeeApp.business.Managers
{
    public class EmployeManager : IEmployeeManager
    {
        private readonly IEmpolyeeRepo _repo;
        public EmployeManager(IEmpolyeeRepo repo)
        {
            _repo = repo;
        }


        public async Task<EmpDTO> CreateEmpAsync(EmpDTO dto)
        {
            var entity = dto.ToEntity();
            var created = await _repo.CreateEmpAsync(entity);
            return created.ToDTO();
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);

        public async Task<IReadOnlyList<EmpDTO>> GetAllEmployeesAsync()
        {
            var employees = await _repo.GetAllEmployeesAsync();
            return employees.ToDTOList();
        }

        public async Task<EmpDTO?> GetEmployeeIdAsync(int id)
        {
            var employee = await _repo.GetEmployeeIdAsync(id);
            return employee?.ToDTO();
        }

        public async Task<EmpDTO> UpdatedAsync(EmpDTO dto)
        {
            var entity = dto.ToEntity();
            var updated = await _repo.UpdatedAsync(entity);
            return updated.ToDTO();
        }

        public async Task<List<EmpDTO>> FuzzySearchEmployeesAsync(string name)
        {
            var allEmployees = (await GetAllEmployeesAsync()).ToList();

            var fullNames = allEmployees
                .Select(e => $"{e.FirstName} {e.LastName}")
                .ToList();

            var matches = FuzzySharp.Process.ExtractAll(name, fullNames)
                 .OrderByDescending(m => m.Score)
                .Take(5)
                .ToList();

            var matchedEmployees = matches
                .Select(m => allEmployees.First(e => $"{e.FirstName} {e.LastName}" == m.Value))
                .ToList();

            return matchedEmployees;
        }

        public async Task<bool> ExistsAsync(int id) => await _repo.GetEmployeeIdAsync(id) is not  null;
       
    }
}
