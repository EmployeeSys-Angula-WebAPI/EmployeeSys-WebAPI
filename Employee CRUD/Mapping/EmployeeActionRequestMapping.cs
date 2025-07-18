using Employee_CRUD.ActionRequests.Employee;
using EmpolyeeApp.business;

namespace Employee_CRUD;

public static class EmployeeActionRequestMapping
{
    public static EmpDTO ToEmpDTO(this EmployeeActionRequest request)
    {
        return new EmpDTO
        (
            request.FirstName,
            request.LastName,
            request.Email,
            request.Position
        );
    }
}
