using System;
using System.Windows.Forms;
using ziko.Forms;


namespace ziko
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ShowDepartmentsForm();
        }

        private void ShowDepartmentsForm()
        {
            var departmentsForm = new DepartmentsForm();
            departmentsForm.TopLevel = false;
            departmentsForm.FormBorderStyle = FormBorderStyle.None;
            departmentsForm.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(departmentsForm);
            departmentsForm.Show();
        }

        private void ShowEmployeesForm()
        {
            var employeesForm = new EmployeesForm();
            employeesForm.TopLevel = false;
            employeesForm.FormBorderStyle = FormBorderStyle.None;
            employeesForm.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(employeesForm);
            employeesForm.Show();
        }

        private void menuDepartments_Click(object sender, EventArgs e)
        {
            ShowDepartmentsForm();
        }

        private void menuEmployees_Click(object sender, EventArgs e)
        {
            ShowEmployeesForm();
        }

        private void menuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}