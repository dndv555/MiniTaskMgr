namespace MiniTaskMgr
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ListView listViewProcesses;
        private Button btnKillProcess;
        private Button btnRefresh;
        private Button btnRunNew;
        private Label labelProcessCount;
        private ColumnHeader colName;
        private ColumnHeader colPID;
        private ColumnHeader colMemory;
        private ColumnHeader colResponding;

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
            listViewProcesses = new ListView();
            colName = new ColumnHeader();
            colPID = new ColumnHeader();
            colMemory = new ColumnHeader();
            colResponding = new ColumnHeader();
            btnKillProcess = new Button();
            btnRefresh = new Button();
            btnRunNew = new Button();
            labelProcessCount = new Label();
            SuspendLayout();
            // 
            // listViewProcesses
            // 
            listViewProcesses.Columns.AddRange(new ColumnHeader[] { colName, colPID, colMemory, colResponding });
            listViewProcesses.FullRowSelect = true;
            listViewProcesses.GridLines = true;
            listViewProcesses.Location = new Point(12, 12);
            listViewProcesses.Name = "listViewProcesses";
            listViewProcesses.Size = new Size(600, 350);
            listViewProcesses.TabIndex = 0;
            listViewProcesses.UseCompatibleStateImageBehavior = false;
            listViewProcesses.View = View.Details;
            // 
            // colName
            // 
            colName.Text = "Имя процесса";
            colName.Width = 150;
            // 
            // colPID
            // 
            colPID.Text = "PID";
            colPID.Width = 80;
            // 
            // colMemory
            // 
            colMemory.Text = "Память";
            colMemory.Width = 100;
            // 
            // colResponding
            // 
            colResponding.Text = "Отвечает";
            colResponding.Width = 80;
            // 
            // btnKillProcess
            // 
            btnKillProcess.Location = new Point(12, 380);
            btnKillProcess.Name = "btnKillProcess";
            btnKillProcess.Size = new Size(130, 30);
            btnKillProcess.TabIndex = 1;
            btnKillProcess.Text = "Завершить процесс";
            btnKillProcess.UseVisualStyleBackColor = true;
            btnKillProcess.Click += btnKillProcess_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(150, 380);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(130, 30);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Обновить процессы";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnRunNew
            // 
            btnRunNew.Location = new Point(290, 380);
            btnRunNew.Name = "btnRunNew";
            btnRunNew.Size = new Size(120, 30);
            btnRunNew.TabIndex = 3;
            btnRunNew.Text = "Запустить программу";
            btnRunNew.UseVisualStyleBackColor = true;
            btnRunNew.Click += btnRunNew_Click;
            // 
            // labelProcessCount
            // 
            labelProcessCount.AutoSize = true;
            labelProcessCount.Location = new Point(420, 387);
            labelProcessCount.Name = "labelProcessCount";
            labelProcessCount.Size = new Size(80, 15);
            labelProcessCount.TabIndex = 4;
            labelProcessCount.Text = "Процессов: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 444);
            Controls.Add(labelProcessCount);
            Controls.Add(btnRunNew);
            Controls.Add(btnRefresh);
            Controls.Add(btnKillProcess);
            Controls.Add(listViewProcesses);
            Name = "Form1";
            Text = "Mini Task Manager";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}