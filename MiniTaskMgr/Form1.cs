using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MiniTaskMgr
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer refreshTimer; 

        public Form1()
        {
            InitializeComponent(); 
            RefreshProcessList();
        }



        private void RefreshProcessList()
        {
            listViewProcesses.BeginUpdate();
            listViewProcesses.Items.Clear();

            try
            {
                var processes = Process.GetProcesses()
                    .OrderBy(p => p.ProcessName)
                    .ToList();

                foreach (var process in processes)
                {
                    try
                    {
                        var item = new ListViewItem(process.ProcessName);
                        item.SubItems.Add(process.Id.ToString());
                        item.SubItems.Add($"{process.WorkingSet64 / 1024 / 1024} MB");
                        item.SubItems.Add(process.Responding ? "Да" : "Нет");
                        item.Tag = process;

                        listViewProcesses.Items.Add(item);
                    }
                    catch
                    {
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления списка: {ex.Message}");
            }

            listViewProcesses.EndUpdate();
            UpdateProcessCount();
        }

        private void UpdateProcessCount()
        {
            labelProcessCount.Text = $"Процессов: {listViewProcesses.Items.Count}";
        }

        private void btnKillProcess_Click(object sender, EventArgs e)
        {
            if (listViewProcesses.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите процесс для завершения");
                return;
            }

            var selectedItem = listViewProcesses.SelectedItems[0];
            var process = selectedItem.Tag as Process;

            if (process != null)
            {
                try
                {
                    process.Kill();
                    MessageBox.Show($"Процесс {process.ProcessName} завершен");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка завершения процесса: {ex.Message}");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshProcessList();
        }

        private void btnRunNew_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Executable files (*.exe)|*.exe|All files (*.*)|*.*";
                dialog.Title = "Запуск программы";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Process.Start(dialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка запуска: {ex.Message}");
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshTimer?.Stop();
        }
    }
}