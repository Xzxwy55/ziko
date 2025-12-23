namespace ziko.Forms
{
    partial class DepartmentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridViewDepartments;
        private System.Windows.Forms.Button btnAddDepartment;
        private System.Windows.Forms.Button btnEditDepartment;
        private System.Windows.Forms.Button btnDeleteDepartment;
        private System.Windows.Forms.Button btnRefresh;

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
            this.dataGridViewDepartments = new System.Windows.Forms.DataGridView();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.btnEditDepartment = new System.Windows.Forms.Button();
            this.btnDeleteDepartment = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).BeginInit();
            this.SuspendLayout();

            // dataGridViewDepartments
            this.dataGridViewDepartments.AllowUserToAddRows = false;
            this.dataGridViewDepartments.AllowUserToDeleteRows = false;
            this.dataGridViewDepartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDepartments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDepartments.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewDepartments.MultiSelect = false;
            this.dataGridViewDepartments.Name = "dataGridViewDepartments";
            this.dataGridViewDepartments.ReadOnly = true;
            this.dataGridViewDepartments.RowHeadersVisible = false;
            this.dataGridViewDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDepartments.Size = new System.Drawing.Size(976, 534);
            this.dataGridViewDepartments.TabIndex = 0;

            // btnAddDepartment
            this.btnAddDepartment.Location = new System.Drawing.Point(12, 12);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(100, 30);
            this.btnAddDepartment.TabIndex = 1;
            this.btnAddDepartment.Text = "Добавить";
            this.btnAddDepartment.UseVisualStyleBackColor = true;
            this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);

            // btnEditDepartment
            this.btnEditDepartment.Location = new System.Drawing.Point(118, 12);
            this.btnEditDepartment.Name = "btnEditDepartment";
            this.btnEditDepartment.Size = new System.Drawing.Size(100, 30);
            this.btnEditDepartment.TabIndex = 2;
            this.btnEditDepartment.Text = "Изменить";
            this.btnEditDepartment.UseVisualStyleBackColor = true;
            this.btnEditDepartment.Click += new System.EventHandler(this.btnEditDepartment_Click);

            // btnDeleteDepartment
            this.btnDeleteDepartment.Location = new System.Drawing.Point(224, 12);
            this.btnDeleteDepartment.Name = "btnDeleteDepartment";
            this.btnDeleteDepartment.Size = new System.Drawing.Size(100, 30);
            this.btnDeleteDepartment.TabIndex = 3;
            this.btnDeleteDepartment.Text = "Удалить";
            this.btnDeleteDepartment.UseVisualStyleBackColor = true;
            this.btnDeleteDepartment.Click += new System.EventHandler(this.btnDeleteDepartment_Click);

            // btnRefresh
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(888, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // DepartmentsForm
            this.ClientSize = new System.Drawing.Size(1000, 596);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDeleteDepartment);
            this.Controls.Add(this.btnEditDepartment);
            this.Controls.Add(this.btnAddDepartment);
            this.Controls.Add(this.dataGridViewDepartments);
            this.Name = "DepartmentsForm";
            this.Text = "Управление отделами";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDepartments)).EndInit();
            this.ResumeLayout(false);
        }
    }
}