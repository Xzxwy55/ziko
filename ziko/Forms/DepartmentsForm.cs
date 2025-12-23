using DAL.Services;
using Domain;
namespace ziko.Forms
{
    public partial class DepartmentsForm : Form
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsForm()
        {
            InitializeComponent();
            _departmentService = new DepartmentService();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                var departments = _departmentService.GetAllDepartments();
                dataGridViewDepartments.DataSource = departments;

                // Настройка столбцов
                dataGridViewDepartments.Columns["Id"].Visible = false;
                dataGridViewDepartments.Columns["Name"].HeaderText = "Название";
                dataGridViewDepartments.Columns["Code"].HeaderText = "Код";
                dataGridViewDepartments.Columns["ParentDepartmentName"].HeaderText = "Родительский отдел";
                dataGridViewDepartments.Columns["Description"].HeaderText = "Описание";
                dataGridViewDepartments.Columns["CreatedDate"].HeaderText = "Дата создания";
                dataGridViewDepartments.Columns["ParentDepartmentId"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                var editForm = new DepartmentEditForm(null, _departmentService);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDepartments();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDepartments.SelectedRows.Count > 0)
                {
                    var department = (Department)dataGridViewDepartments.SelectedRows[0].DataBoundItem;
                    var editForm = new DepartmentEditForm(department, _departmentService);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadDepartments();
                    }
                }
                else
                {
                    MessageBox.Show("Выберите отдел для редактирования",
                        "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewDepartments.SelectedRows.Count > 0)
                {
                    var department = (Department)dataGridViewDepartments.SelectedRows[0].DataBoundItem;

                    var result = MessageBox.Show($"Удалить отдел '{department.Name}'?",
                        "Подтверждение удаления",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        var deleteResult = _departmentService.DeleteDepartment(department.Id);

                        if (deleteResult)
                        {
                            LoadDepartments();
                            MessageBox.Show("Отдел успешно удален",
                                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Невозможно удалить отдел. Проверьте, что:\n" +
                                          "1. В отделе нет сотрудников\n" +
                                          "2. У отдела нет подразделений",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите отдел для удаления",
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
            LoadDepartments();
        }
    }
}
