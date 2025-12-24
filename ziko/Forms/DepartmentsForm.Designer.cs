namespace ziko.Forms
{
    partial class DepartmentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewDepartments;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.Button btnEditDepartment;
        private System.Windows.Forms.Button btnDeleteDepartment;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dataGridViewDepartments = new DataGridView();
            btnAddDepartment = new Button();
            btnEditDepartment = new Button();
            btnDeleteDepartment = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartments).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewDepartments
            // 
            dataGridViewDepartments.AllowUserToAddRows = false;
            dataGridViewDepartments.AllowUserToDeleteRows = false;
            dataGridViewDepartments.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDepartments.Location = new Point(118, 12);
            dataGridViewDepartments.MultiSelect = false;
            dataGridViewDepartments.Name = "dataGridViewDepartments";
            dataGridViewDepartments.ReadOnly = true;
            dataGridViewDepartments.RowHeadersVisible = false;
            dataGridViewDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewDepartments.Size = new Size(1029, 551);
            dataGridViewDepartments.TabIndex = 0;
            // 
            // btnAddDepartment
            // 
            btnAddDepartment.BackColor = SystemColors.Highlight;
            btnAddDepartment.Location = new Point(12, 12);
            btnAddDepartment.Name = "btnAddDepartment";
            btnAddDepartment.Size = new Size(100, 30);
            btnAddDepartment.TabIndex = 1;
            btnAddDepartment.Text = "Добавить";
            btnAddDepartment.UseVisualStyleBackColor = false;
            btnAddDepartment.Click += btnAddDepartment_Click;
            // 
            // btnEditDepartment
            // 
            btnEditDepartment.BackColor = SystemColors.Highlight;
            btnEditDepartment.Location = new Point(12, 48);
            btnEditDepartment.Name = "btnEditDepartment";
            btnEditDepartment.Size = new Size(100, 30);
            btnEditDepartment.TabIndex = 2;
            btnEditDepartment.Text = "Изменить";
            btnEditDepartment.UseVisualStyleBackColor = false;
            btnEditDepartment.Click += btnEditDepartment_Click;
            // 
            // btnDeleteDepartment
            // 
            btnDeleteDepartment.BackColor = Color.Red;
            btnDeleteDepartment.Location = new Point(12, 120);
            btnDeleteDepartment.Name = "btnDeleteDepartment";
            btnDeleteDepartment.Size = new Size(100, 30);
            btnDeleteDepartment.TabIndex = 3;
            btnDeleteDepartment.Text = "Удалить";
            btnDeleteDepartment.UseVisualStyleBackColor = false;
            btnDeleteDepartment.Click += btnDeleteDepartment_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.Highlight;
            btnRefresh.Location = new Point(12, 84);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 30);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "обновить ";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // DepartmentsForm
            // 
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1159, 577);
            Controls.Add(btnRefresh);
            Controls.Add(btnDeleteDepartment);
            Controls.Add(btnEditDepartment);
            Controls.Add(btnAddDepartment);
            Controls.Add(dataGridViewDepartments);
            Name = "DepartmentsForm";
            Text = "Управление отделами";
            ((System.ComponentModel.ISupportInitialize)dataGridViewDepartments).EndInit();
            ResumeLayout(false);
        }
        private Button btnRefresh;
    }
}