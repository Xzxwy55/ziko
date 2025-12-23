using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace DAL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly string _connectionString;

        public EmployeeService()
        {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True";
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT e.Id, e.FirstName, e.LastName, e.MiddleName, 
                               e.Position, e.DepartmentId, e.Phone, e.Email, 
                               e.HireDate, d.Name as DepartmentName
                        FROM Employees e
                        LEFT JOIN Departments d ON e.DepartmentId = d.Id
                        ORDER BY e.LastName, e.FirstName";

                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employee = new Employee
                            {
                                Id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                LastName = reader.GetString(2),
                                MiddleName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                Position = reader.GetString(4),
                                DepartmentId = reader.GetInt32(5),
                                Phone = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                Email = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                HireDate = reader.GetDateTime(8),
                                DepartmentName = reader.IsDBNull(9) ? "Не назначен" : reader.GetString(9)
                            };

                            employees.Add(employee);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке сотрудников: {ex.Message}");
                throw;
            }

            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT e.Id, e.FirstName, e.LastName, e.MiddleName, 
                               e.Position, e.DepartmentId, e.Phone, e.Email, 
                               e.HireDate, d.Name as DepartmentName
                        FROM Employees e
                        LEFT JOIN Departments d ON e.DepartmentId = d.Id
                        WHERE e.Id = @Id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Employee
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    MiddleName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                    Position = reader.GetString(4),
                                    DepartmentId = reader.GetInt32(5),
                                    Phone = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                    Email = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                    HireDate = reader.GetDateTime(8),
                                    DepartmentName = reader.IsDBNull(9) ? "Не назначен" : reader.GetString(9)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при получении сотрудника: {ex.Message}");
                throw;
            }

            return null;
        }

        public bool AddEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Employees (FirstName, LastName, MiddleName, Position, 
                                               DepartmentId, Phone, Email, HireDate)
                        VALUES (@FirstName, @LastName, @MiddleName, @Position, 
                                @DepartmentId, @Phone, @Email, @HireDate);
                        SELECT SCOPE_IDENTITY();";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue("@LastName", employee.LastName);
                        command.Parameters.AddWithValue("@MiddleName",
                            string.IsNullOrEmpty(employee.MiddleName) ? (object)DBNull.Value : employee.MiddleName);
                        command.Parameters.AddWithValue("@Position", employee.Position);
                        command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                        command.Parameters.AddWithValue("@Phone",
                            string.IsNullOrEmpty(employee.Phone) ? (object)DBNull.Value : employee.Phone);
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrEmpty(employee.Email) ? (object)DBNull.Value : employee.Email);
                        command.Parameters.AddWithValue("@HireDate", employee.HireDate);

                        var newId = command.ExecuteScalar();
                        employee.Id = Convert.ToInt32(newId);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении сотрудника: {ex.Message}");
                throw;
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        UPDATE Employees 
                        SET FirstName = @FirstName, 
                            LastName = @LastName,
                            MiddleName = @MiddleName,
                            Position = @Position,
                            DepartmentId = @DepartmentId,
                            Phone = @Phone,
                            Email = @Email,
                            HireDate = @HireDate
                        WHERE Id = @Id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", employee.Id);
                        command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        command.Parameters.AddWithValue("@LastName", employee.LastName);
                        command.Parameters.AddWithValue("@MiddleName",
                            string.IsNullOrEmpty(employee.MiddleName) ? (object)DBNull.Value : employee.MiddleName);
                        command.Parameters.AddWithValue("@Position", employee.Position);
                        command.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                        command.Parameters.AddWithValue("@Phone",
                            string.IsNullOrEmpty(employee.Phone) ? (object)DBNull.Value : employee.Phone);
                        command.Parameters.AddWithValue("@Email",
                            string.IsNullOrEmpty(employee.Email) ? (object)DBNull.Value : employee.Email);
                        command.Parameters.AddWithValue("@HireDate", employee.HireDate);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении сотрудника: {ex.Message}");
                throw;
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                // Проверяем, не связан ли сотрудник с оборудованием
                if (HasAssignedEquipment(id))
                {
                    return false; // Есть привязанное оборудование
                }

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Employees WHERE Id = @Id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении сотрудника: {ex.Message}");
                throw;
            }
        }

        private bool HasAssignedEquipment(int employeeId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Equipment WHERE CurrentOwnerId = @EmployeeId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public List<Employee> GetEmployeesByDepartment(int departmentId)
        {
            var employees = new List<Employee>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT e.Id, e.FirstName, e.LastName, e.MiddleName, 
                               e.Position, e.DepartmentId, e.Phone, e.Email, 
                               e.HireDate, d.Name as DepartmentName
                        FROM Employees e
                        LEFT JOIN Departments d ON e.DepartmentId = d.Id
                        WHERE e.DepartmentId = @DepartmentId
                        ORDER BY e.LastName, e.FirstName";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DepartmentId", departmentId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var employee = new Employee
                                {
                                    Id = reader.GetInt32(0),
                                    FirstName = reader.GetString(1),
                                    LastName = reader.GetString(2),
                                    MiddleName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                    Position = reader.GetString(4),
                                    DepartmentId = reader.GetInt32(5),
                                    Phone = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                                    Email = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                                    HireDate = reader.GetDateTime(8),
                                    DepartmentName = reader.IsDBNull(9) ? "Не назначен" : reader.GetString(9)
                                };

                                employees.Add(employee);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке сотрудников отдела: {ex.Message}");
                throw;
            }

            return employees;
        }
    }
}