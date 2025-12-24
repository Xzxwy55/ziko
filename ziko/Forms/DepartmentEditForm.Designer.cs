namespace ziko.Forms
{

    partial class DepartmentEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.ComboBox cmbParentDepartment;
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
            txtName = new TextBox();
            txtCode = new TextBox();
            txtDescription = new TextBox();
            cmbParentDepartment = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(60, 13);
            label1.TabIndex = 0;
            label1.Text = "Название:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(29, 13);
            label2.TabIndex = 1;
            label2.Text = "Код:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 105);
            label3.Name = "label3";
            label3.Size = new Size(60, 13);
            label3.TabIndex = 2;
            label3.Text = "Описание:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 75);
            label4.Name = "label4";
            label4.Size = new Size(114, 13);
            label4.TabIndex = 3;
            label4.Text = "Родительский отдел:";
            // 
            // txtName
            // 
            txtName.Location = new Point(130, 12);
            txtName.Name = "txtName";
            txtName.Size = new Size(165, 22);
            txtName.TabIndex = 4;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(130, 42);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(165, 22);
            txtCode.TabIndex = 5;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(130, 102);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(165, 100);
            txtDescription.TabIndex = 6;
            // 
            // cmbParentDepartment
            // 
            cmbParentDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbParentDepartment.FormattingEnabled = true;
            cmbParentDepartment.Location = new Point(130, 72);
            cmbParentDepartment.Name = "cmbParentDepartment";
            cmbParentDepartment.Size = new Size(165, 21);
            cmbParentDepartment.TabIndex = 7;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.MenuHighlight;
            btnSave.Location = new Point(22, 172);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 30);
            btnSave.TabIndex = 8;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.MenuHighlight;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(22, 208);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 30);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // DepartmentEditForm
            // 
            AcceptButton = btnSave;
            BackColor = SystemColors.ActiveCaption;
            CancelButton = btnCancel;
            ClientSize = new Size(323, 250);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbParentDepartment);
            Controls.Add(txtDescription);
            Controls.Add(txtCode);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DepartmentEditForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Редактирование отдела";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}