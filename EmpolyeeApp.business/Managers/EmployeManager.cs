using EmployeeApp.DAL.Infrastructure;
using EmployeeApp.Domain;
using EmpolyeeApp.business.Contracts;

namespace EmpolyeeApp.business.Managers
{
    public class EmployeManager(IEmpolyeeRepo repo) : IEmolyeeManager
    {
        private readonly IEmpolyeeRepo _repo = repo;

        

        public Task<Employee> CreateEmpAsync(Employee entity) => _repo.CreateEmpAsync(entity);
  

        public Task<bool> DeleteAsync(int id)  => _repo.DeleteAsync(id);
      

        public Task<IReadOnlyList<Employee>> GetAllEmployeesAsync() => _repo.GetAllEmployeesAsync();


        public Task<Employee?> GetEmployeeIdAsync(int id) => _repo.GetEmployeeIdAsync(id);


        public Task<Employee> UpdatedAsync(Employee entity) => _repo.UpdatedAsync(entity);

    }
}
