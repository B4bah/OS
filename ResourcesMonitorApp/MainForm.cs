using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SystemInfoApp
{
    public class MainForm : Form
    {
        private DataGridView dataGridView;

        public MainForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "System Information (WMI)";
            this.Size = new System.Drawing.Size(800, 600);

            dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            dataGridView.Columns.Add("PropertyName", "Property");
            dataGridView.Columns.Add("PropertyValue", "Value");

            this.Controls.Add(dataGridView);
        }

        private void LoadData()
        {
            try
            {
                var manager = new SystemInfoManager("Win32_Processor");
                List<SystemInfoManager.Property> properties = manager.GetInfo();

                foreach (var prop in properties)
                {
                    dataGridView.Rows.Add(prop.Name, prop.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}