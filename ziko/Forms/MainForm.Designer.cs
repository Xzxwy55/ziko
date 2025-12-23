namespace ziko
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuManagement;
        private System.Windows.Forms.ToolStripMenuItem menuDepartments;
        private System.Windows.Forms.ToolStripMenuItem menuEmployees;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;

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
            menuStrip1 = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuExit = new ToolStripMenuItem();
            menuManagement = new ToolStripMenuItem();
            menuDepartments = new ToolStripMenuItem();
            menuEmployees = new ToolStripMenuItem();
            panelMain = new Panel();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuFile, menuManagement });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(1167, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(48, 20);
            menuFile.Text = "Файл";
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(109, 22);
            menuExit.Text = "Выход";
            menuExit.Click += menuExit_Click;
            // 
            // menuManagement
            // 
            menuManagement.DropDownItems.AddRange(new ToolStripItem[] { menuDepartments, menuEmployees });
            menuManagement.Name = "menuManagement";
            menuManagement.Size = new Size(85, 20);
            menuManagement.Text = "Управление";
            // 
            // menuDepartments
            // 
            menuDepartments.Name = "menuDepartments";
            menuDepartments.Size = new Size(140, 22);
            menuDepartments.Text = "Отделы";
            menuDepartments.Click += menuDepartments_Click;
            // 
            // menuEmployees
            // 
            menuEmployees.Name = "menuEmployees";
            menuEmployees.Size = new Size(140, 22);
            menuEmployees.Text = "Сотрудники";
            menuEmployees.Click += menuEmployees_Click;
            // 
            // panelMain
            // 
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 24);
            panelMain.Margin = new Padding(4, 3, 4, 3);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1167, 695);
            panelMain.TabIndex = 1;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(0, 719);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(1167, 22);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(169, 17);
            statusLabel.Text = "Система учета оборудования";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1167, 741);
            Controls.Add(panelMain);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(931, 686);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Система учета оборудования";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}