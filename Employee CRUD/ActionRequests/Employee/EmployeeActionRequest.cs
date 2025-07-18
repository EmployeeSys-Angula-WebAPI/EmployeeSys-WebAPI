using System.ComponentModel.DataAnnotations;

namespace Employee_CRUD.ActionRequests.Employee;

public class EmployeeActionRequest
{
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters.")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First name can contain letters only.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters.")]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name can contain letters only.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Position is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Position must be between 2 and 100 characters.")]
    public string Position { get; set; } = string.Empty;

    #region ValidationContext
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (FirstName.Equals(LastName, StringComparison.OrdinalIgnoreCase))
        {
            yield return new ValidationResult("First and last names cannot be the same.", new[] { "FirstName", "LastName" });
        }
    }
    #endregion
}

