namespace EmpolyeeApp.business
{
    public class EmpDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string Position { get; set; } 

        public EmpDTO(string fristName ,string lastName ,string email , string position)
        {
            FirstName = fristName ?? throw new ArgumentNullException(nameof(fristName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(Email));
            Position = position ?? throw new ArgumentNullException(nameof(position));
        }
       

    }
}
