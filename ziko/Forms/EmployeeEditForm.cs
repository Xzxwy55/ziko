using DAL.Services;
using Domain;
using System;
using System.Windows.Forms;

namespace ziko
{
    public partial class EmployeeEditForm : Form
    {
        private readonly Employee _employee;
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeEditForm(Employee employee, IEmployeeService employeeService, IDepartmentService departmentService)
        {
            InitializeComponent();
            _employeeService = employeeService;
            _departmentService = departmentService;
            _employee = employee ?? new Employee();
            LoadDepartments();
            LoadData();
        }

        private void LoadData()
        {
            if (_employee.Id > 0)
            {
                this.Text = "Редактирование сотрудника";
                txtFirstName.Text = _employee.FirstName;
                txtLastName.Text = _employee.LastName;
                txtMiddleName.Text = _employee.MiddleName;
                txtPosition.Text = _employee.Position;
                txtPhone.Text = _employee.Phone;
                txtEmail.Text = _employee.Email;
                dateHireDate.Value = _employee.HireDate;

                if (_employee.DepartmentId > 0)
                {
                    cmbDepartment.SelectedValue = _employee.DepartmentId;
                }
            }
            else
            {
                this.Text = "Добавление сотрудника";
                dateHireDate.Value = DateTime.Now;
            }
        }

        private void LoadDepartments()
        {
            try
            {
                var departments = _departmentService.GetParentDepartments();
                departments.Insert(0, new Department { Id = -1, Name = "(не выбран)" });

                cmbDepartment.DataSource = departments;
                cmbDepartment.DisplayMember = "Name";
                cmbDepartment.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки отделов: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                _employee.FirstName = txtFirstName.Text.Trim();
                _employee.LastName = txtLastName.Text.Trim();
                _employee.MiddleName = txtMiddleName.Text.Trim();
                _employee.Position = txtPosition.Text.Trim();
                _employee.Phone = txtPhone.Text.Trim();
                _employee.Email = txtEmail.Text.Trim();
                _employee.HireDate = dateHireDate.Value;

                if (cmbDepartment.SelectedValue != null &&
                    (int)cmbDepartment.SelectedValue > 0)
                {
                    _employee.DepartmentId = (int)cmbDepartment.SelectedValue;
                }
                else
                {
                    _employee.DepartmentId = 0;
                }

                bool success;
                if (_employee.Id > 0)
                {
                    success = _employeeService.UpdateEmployee(_employee);
                }
                else
                {
                    success = _employeeService.AddEmployee(_employee);
                }

                if (success)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("Введите имя сотрудника", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Введите фамилию сотрудника", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Введите должность сотрудника", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPosition.Focus();
                return false;
            }

            if (cmbDepartment.SelectedValue == null ||
                (int)cmbDepartment.SelectedValue <= 0)
            {
                MessageBox.Show("Выберите отдел для сотрудника", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartment.Focus();
                return false;
            }

            // Проверка email
            if (!string.IsNullOrWhiteSpace(txtEmail.Text) &&
                !IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Введите корректный email адрес", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}