namespace ziko
{
    partial class EmployeeEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.DateTimePicker dateHireDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtMiddleName = new TextBox();
            txtPosition = new TextBox();
            cmbDepartment = new ComboBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            dateHireDate = new DateTimePicker();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(32, 13);
            label1.TabIndex = 0;
            label1.Text = "Имя:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(59, 13);
            label2.TabIndex = 1;
            label2.Text = "Фамилия:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 75);
            label3.Name = "label3";
            label3.Size = new Size(57, 13);
            label3.TabIndex = 2;
            label3.Text = "Отчество:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 105);
            label4.Name = "label4";
            label4.Size = new Size(68, 13);
            label4.TabIndex = 3;
            label4.Text = "Должность:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 135);
            label5.Name = "label5";
            label5.Size = new Size(41, 13);
            label5.TabIndex = 4;
            label5.Text = "Отдел:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 165);
            label6.Name = "label6";
            label6.Size = new Size(55, 13);
            label6.TabIndex = 5;
            label6.Text = "Телефон:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 195);
            label7.Name = "label7";
            label7.Size = new Size(35, 13);
            label7.TabIndex = 6;
            label7.Text = "Email:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 225);
            label8.Name = "label8";
            label8.Size = new Size(129, 13);
            label8.TabIndex = 7;
            label8.Text = "Дата приема на работу:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(130, 12);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(250, 22);
            txtFirstName.TabIndex = 8;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(130, 42);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(250, 22);
            txtLastName.TabIndex = 9;
            // 
            // txtMiddleName
            // 
            txtMiddleName.Location = new Point(130, 72);
            txtMiddleName.Name = "txtMiddleName";
            txtMiddleName.Size = new Size(250, 22);
            txtMiddleName.TabIndex = 10;
            // 
            // txtPosition
            // 
            txtPosition.Location = new Point(130, 102);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(250, 22);
            txtPosition.TabIndex = 11;
            // 
            // cmbDepartment
            // 
            cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(130, 132);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(250, 21);
            cmbDepartment.TabIndex = 12;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(130, 162);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 22);
            txtPhone.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(130, 192);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 22);
            txtEmail.TabIndex = 14;
            // 
            // dateHireDate
            // 
            dateHireDate.Location = new Point(130, 222);
            dateHireDate.Name = "dateHireDate";
            dateHireDate.Size = new Size(250, 22);
            dateHireDate.TabIndex = 15;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Highlight;
            btnSave.Location = new Point(258, 260);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(96, 30);
            btnSave.TabIndex = 16;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Highlight;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(45, 260);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(96, 30);
            btnCancel.TabIndex = 17;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // EmployeeEditForm
            // 
            AcceptButton = btnSave;
            BackColor = SystemColors.ActiveCaption;
            CancelButton = btnCancel;
            ClientSize = new Size(411, 313);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(dateHireDate);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(cmbDepartment);
            Controls.Add(txtPosition);
            Controls.Add(txtMiddleName);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EmployeeEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактирование сотрудника";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}