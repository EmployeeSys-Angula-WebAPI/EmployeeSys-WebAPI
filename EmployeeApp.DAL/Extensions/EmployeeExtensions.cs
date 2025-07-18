using EmployeeApp.Domain;

namespace EmployeeApp.DAL.Extensions
{
    public static class EmployeeExtensions
    {
        public static void UpdateWith(this Employee target, Employee source)
        {
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.Email = source.Email;
            target.Position = source.Position;
        }
    }
}
