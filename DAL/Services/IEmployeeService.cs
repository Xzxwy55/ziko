using Domain;

namespace DAL.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        bool AddEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
        List<Employee> GetEmployeesByDepartment(int departmentId);
    }
}
