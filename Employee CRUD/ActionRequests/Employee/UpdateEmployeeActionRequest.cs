using EmpolyeeApp.business;

namespace Employee_CRUD.ActionRequests.Employee;

public class UpdateEmployeeActionRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Position { get; set; }

    public EmpDTO ToEmpDTO(int id)
    {
        return
        new EmpDTO
        (
        FirstName,
        LastName, 
        Email,
        Position
        )
        {
            Id = id
        };
    } 
}
