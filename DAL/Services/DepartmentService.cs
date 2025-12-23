using Domain;
using System.Data.SqlClient;
namespace DAL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly string _connectionString;

        public DepartmentService()
        {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB;Integrated Security=True";
        }

        public List<Department> GetAllDepartments()
        {
            var departments = new List<Department>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT d.Id, d.Name, d.Code, d.ParentDepartmentId, p.Name as ParentName
                        FROM Departments d
                        LEFT JOIN Departments p ON d.ParentDepartmentId = p.Id
                        ORDER BY d.Name";

                    using (var command = new SqlCommand(query, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var department = new Department
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Code = reader.GetString(2),
                                Description = $"Code: {reader.GetString(2)}",
                                CreatedDate = DateTime.Now
                            };

                            if (!reader.IsDBNull(3))
                            {
                                department.ParentDepartmentId = reader.GetInt32(3);
                            }

                            if (!reader.IsDBNull(4))
                            {
                                department.ParentDepartmentName = reader.GetString(4);
                            }

                            departments.Add(department);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Логирование в консоль (в реальном проекте используйте ILogger)
                Console.WriteLine($"Ошибка при загрузке отделов: {ex.Message}");
                throw;
            }

            return departments;
        }

        public bool AddDepartment(Department department)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        INSERT INTO Departments (Name, Code, ParentDepartmentId)
                        VALUES (@Name, @Code, @ParentId);
                        SELECT SCOPE_IDENTITY();";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", department.Name);
                        command.Parameters.AddWithValue("@Code", department.Code);

                        if (department.ParentDepartmentId.HasValue)
                        {
                            command.Parameters.AddWithValue("@ParentId", department.ParentDepartmentId.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ParentId", DBNull.Value);
                        }

                        var newId = command.ExecuteScalar();
                        department.Id = Convert.ToInt32(newId);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении отдела: {ex.Message}");
                throw;
            }
        }

        public bool UpdateDepartment(Department department)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        UPDATE Departments 
                        SET Name = @Name, 
                            Code = @Code, 
                            ParentDepartmentId = @ParentId
                        WHERE Id = @Id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", department.Id);
                        command.Parameters.AddWithValue("@Name", department.Name);
                        command.Parameters.AddWithValue("@Code", department.Code);

                        if (department.ParentDepartmentId.HasValue)
                        {
                            command.Parameters.AddWithValue("@ParentId", department.ParentDepartmentId.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ParentId", DBNull.Value);
                        }

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обновлении отдела: {ex.Message}");
                throw;
            }
        }

        public bool DeleteDepartment(int id)
        {
            try
            {
                // Проверяем наличие подотделов
                if (HasSubDepartments(id))
                {
                    // Не удаляем - эту ошибку обработаем в UI
                    return false;
                }

                // Проверяем наличие сотрудников
                if (HasEmployees(id))
                {
                    // Не удаляем - эту ошибку обработаем в UI
                    return false;
                }

                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Departments WHERE Id = @Id";

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
                Console.WriteLine($"Ошибка при удалении отдела: {ex.Message}");
                throw;
            }
        }

        private bool HasSubDepartments(int departmentId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Departments WHERE ParentDepartmentId = @Id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", departmentId);
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

        private bool HasEmployees(int departmentId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Employees WHERE DepartmentId = @Id";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", departmentId);
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

        public List<Department> GetParentDepartments(int? excludeId = null)
        {
            var departments = new List<Department>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Name, Code, ParentDepartmentId
                        FROM Departments 
                        WHERE (@ExcludeId IS NULL OR Id != @ExcludeId)
                        ORDER BY Name";

                    using (var command = new SqlCommand(query, connection))
                    {
                        if (excludeId.HasValue)
                        {
                            command.Parameters.AddWithValue("@ExcludeId", excludeId.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@ExcludeId", DBNull.Value);
                        }

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                departments.Add(new Department
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Code = reader.GetString(2),
                                    ParentDepartmentId = reader.IsDBNull(3) ? null : (int?)reader.GetInt32(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке отделов: {ex.Message}");
                throw;
            }

            return departments;
        }
    }
}