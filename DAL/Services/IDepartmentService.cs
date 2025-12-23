using Domain;

namespace DAL.Services
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        bool AddDepartment(Department department);
        bool UpdateDepartment(Department department);
        bool DeleteDepartment(int id);
        List<Department> GetParentDepartments(int? excludeId = null);
    }
}
