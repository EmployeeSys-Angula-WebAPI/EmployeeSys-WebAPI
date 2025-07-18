using EmployeeApp.Domain;
using EmpolyeeApp.business.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeManager manager) : ControllerBase
    {
        private readonly IEmployeeManager _manager = manager;

        // GET: api/employees
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _manager.GetAllEmployeesAsync();
            return Ok(employees);
        }

        // GET: api/employees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _manager.GetEmployeeIdAsync(id);
            if (emp is null) return NotFound();
            return Ok(emp);
        }

        // POST: api/employees
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var created = await _manager.CreateEmpAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/employees
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Employee employee)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updated = await _manager.UpdatedAsync(employee);
            return Ok(updated);
        }

        // DELETE: api/employees/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _manager.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        // GET: api/employees/search?query=rawan
        [HttpGet("fuzzy-search")]
        public async Task<IActionResult> FuzzySearch([FromQuery] string name)
        {
            var result = await _manager.FuzzySearchEmployeesAsync(name);
            return Ok(result);
        }

    }
}
