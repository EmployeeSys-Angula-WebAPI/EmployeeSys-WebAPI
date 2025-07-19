using Employee_CRUD.ActionRequests.Employee;
using EmployeeApp.Domain;
using EmpolyeeApp.business.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Employee_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeManager _manager;
        public EmployeesController(IEmployeeManager manager)
        {
            _manager=manager;
        }


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
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeActionRequest request)
        {
            if (request == null)
                return BadRequest("Request body cannot be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var dto = request.ToEmpDTO();

            var created = await _manager.CreateEmpAsync(dto);

            if (created == null)
                return StatusCode(500, "An error occurred while creating the employee.");

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }


        // POST: api/employees
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeActionRequest request)
        {
            if (request == null)
                return BadRequest("Request body cannot be null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = await _manager.ExistsAsync(id);
            if (!exists)
                return NotFound($"Employee with ID {id} not found.");

            var dto = request.ToEmpDTO(id); 

            var updated = await _manager.UpdatedAsync(dto);

            if (updated == null)
                return StatusCode(500, "An error occurred while updating the employee.");

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
