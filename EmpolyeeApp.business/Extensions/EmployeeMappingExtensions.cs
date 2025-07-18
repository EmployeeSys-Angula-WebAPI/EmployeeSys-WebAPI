using EmployeeApp.Domain;

namespace EmpolyeeApp.business;

public static class EmployeeMappingExtensions
{
    public static Employee ToEntity(this EmpDTO dto)
    {
        return new Employee
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Position = dto.Position
        };
    }

    public static EmpDTO ToDTO(this Employee entity)
    {
        return new EmpDTO(entity.FirstName, entity.LastName, entity.Email, entity.Position)
        {
            Id = entity.Id
        };
    }
    public static IReadOnlyList<EmpDTO> ToDTOList(this IReadOnlyList<Employee> entities)
    {
        return entities.Select(e => e.ToDTO()).ToList();
    }
}
