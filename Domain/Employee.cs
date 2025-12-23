namespace Domain
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Position { get; set; }
        public int DepartmentId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public string DepartmentName { get; set; }

        public string FullName => $"{LastName} {FirstName} {MiddleName}";
    }
}
