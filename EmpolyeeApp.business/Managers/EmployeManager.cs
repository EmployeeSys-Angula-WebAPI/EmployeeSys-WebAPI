using EmployeeApp.DAL.Infrastructure;
using EmployeeApp.Domain;
using EmpolyeeApp.business.Contracts;
using System.Diagnostics;
using FuzzySharp;


namespace EmpolyeeApp.business.Managers
{
    public class EmployeManager(IEmpolyeeRepo repo) : IEmployeeManager
    {
        private readonly IEmpolyeeRepo _repo = repo;

        

        public Task<Employee> CreateEmpAsync(Employee entity) => _repo.CreateEmpAsync(entity);
  

        public Task<bool> DeleteAsync(int id)  => _repo.DeleteAsync(id);
      

        public Task<IReadOnlyList<Employee>> GetAllEmployeesAsync() => _repo.GetAllEmployeesAsync();


        public Task<Employee?> GetEmployeeIdAsync(int id) => _repo.GetEmployeeIdAsync(id);


        public Task<Employee> UpdatedAsync(Employee entity) => _repo.UpdatedAsync(entity);

        public async Task<List<Employee>> FuzzySearchEmployeesAsync(string name)
        {
            var allEmployees = (await _repo.GetAllEmployeesAsync()).ToList();

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
    }
}
