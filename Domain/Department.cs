namespace Domain
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int? ParentDepartmentId { get; set; }
        public string ParentDepartmentName { get; set; } = string.Empty;
    }
}
