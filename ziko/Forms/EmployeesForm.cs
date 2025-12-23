using DAL.Services;
using Domain;
using System;
using System.Windows.Forms;

namespace ziko
{
    public partial class EmployeesForm : Form
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeesForm()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                var employees = _employeeService.GetAllEmployees();
                dataGridViewEmployees.DataSource = employees;

                // Настройка столбцов
                dataGridViewEmployees.Columns["Id"].Visible = false;
                dataGridViewEmployees.Columns["FirstName"].HeaderText = "Имя";
                dataGridViewEmployees.Columns["LastName"].HeaderText = "Фамилия";
                dataGridViewEmployees.Columns["MiddleName"].HeaderText = "Отчество";
                dataGridViewEmployees.Columns["Position"].HeaderText = "Должность";
                dataGridViewEmployees.Columns["DepartmentName"].HeaderText = "Отдел";
                dataGridViewEmployees.Columns["Phone"].HeaderText = "Телефон";
                dataGridViewEmployees.Columns["Email"].HeaderText = "Email";
                dataGridViewEmployees.Columns["HireDate"].HeaderText = "Дата приема";
                dataGridViewEmployees.Columns["DepartmentId"].Visible = false;
                dataGridViewEmployees.Columns["FullName"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var editForm = new EmployeeEditForm(null, _employeeService, _departmentService);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEmployees.SelectedRows.Count > 0)
                {
                    var employee = (Employee)dataGridViewEmployees.SelectedRows[0].DataBoundItem;
                    var editForm = new EmployeeEditForm(employee, _employeeService, _departmentService);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadEmployees();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите сотрудника для редактирования",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEmployees.SelectedRows.Count > 0)
                {
                    var employee = (Employee)dataGridViewEmployees.SelectedRows[0].DataBoundItem;

                    var result = MessageBox.Show($"Удалить сотрудника '{employee.FullName}'?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var deleteResult = _employeeService.DeleteEmployee(employee.Id);

                        if (deleteResult)
                        {
                            LoadEmployees();
                            MessageBox.Show("Сотрудник успешно удален",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить сотрудника. Возможно у него есть привязанное оборудование.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите сотрудника для удаления",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadEmployees();
        }
    }
}