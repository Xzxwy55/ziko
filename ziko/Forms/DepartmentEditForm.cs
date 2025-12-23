using DAL.Services;
using Domain;


namespace ziko.Forms
{
    public partial class DepartmentEditForm : Form
    {
        private readonly Department _department;
        private readonly IDepartmentService _departmentService;

        public DepartmentEditForm(Department department, IDepartmentService departmentService)
        {
            InitializeComponent();
            _departmentService = departmentService;
            _department = department ?? new Department();
            LoadParentDepartments();
            LoadData();
        }

        private void LoadData()
        {
            if (_department.Id > 0)
            {
                this.Text = "Редактирование отдела";
                txtName.Text = _department.Name;
                txtCode.Text = _department.Code;
                txtDescription.Text = _department.Description;

                if (_department.ParentDepartmentId.HasValue)
                {
                    cmbParentDepartment.SelectedValue = _department.ParentDepartmentId.Value;
                }
            }
            else
            {
                this.Text = "Добавление отдела";
            }
        }

        private void LoadParentDepartments()
        {
            try
            {
                var departments = _departmentService.GetParentDepartments(_department?.Id);
                departments.Insert(0, new Department { Id = -1, Name = "(нет)" });

                cmbParentDepartment.DataSource = departments;
                cmbParentDepartment.DisplayMember = "Name";
                cmbParentDepartment.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                _department.Name = txtName.Text.Trim();
                _department.Code = txtCode.Text.Trim().ToUpper();
                _department.Description = txtDescription.Text.Trim();

                if (cmbParentDepartment.SelectedValue != null &&
                    (int)cmbParentDepartment.SelectedValue > 0)
                {
                    _department.ParentDepartmentId = (int)cmbParentDepartment.SelectedValue;
                }
                else
                {
                    _department.ParentDepartmentId = null;
                }

                bool success;
                if (_department.Id > 0)
                {
                    success = _departmentService.UpdateDepartment(_department);
                }
                else
                {
                    success = _departmentService.AddDepartment(_department);
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
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название отдела", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Введите код отдела", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtCode.Text.Length > 10)
            {
                MessageBox.Show("Код отдела не должен превышать 10 символов", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}