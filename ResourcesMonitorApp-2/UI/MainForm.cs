using System;
using System.Collections.Generic;
using System.Management;
using System.Windows.Forms;

using SystemInfoApp_2.Data;
using SystemInfoApp_2.Models;

namespace SystemInfoApp_2.UI
{
    public class MainForm : Form
    {
        private TabControl tabControl;

        public MainForm()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void InitializeComponent()
        {
            this.Text = "System Information";
            this.Size = new System.Drawing.Size(900, 700);

            tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };

            this.Controls.Add(tabControl);
        }

        private void LoadCategories()
        {
            var categories = WmiDataProvider.GetCategories();
            foreach (var category in categories)
            {
                var tabPage = new TabPage(category.CategoryName);
                var dataGridView = CreateDataGridView();

                var allProperties = new List<WmiProperty>();
                foreach (var cls in category.Classes)
                {
                    allProperties.AddRange(WmiDataProvider.GetProperties(cls.ClassName));
                }

                foreach (var prop in allProperties)
                {
                    dataGridView.Rows.Add(prop.ClassName, prop.PropertyName, prop.PropertyValue);
                }

                tabPage.Controls.Add(dataGridView);
                tabControl.TabPages.Add(tabPage);
            }
        }

        private DataGridView CreateDataGridView()
        {
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgv.Columns.Add("ClassName", "WMI Class");
            dgv.Columns.Add("PropertyName", "Property");
            dgv.Columns.Add("PropertyValue", "Value");
            return dgv;
        }
    }
}