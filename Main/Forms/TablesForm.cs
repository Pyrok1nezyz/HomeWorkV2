using System.Diagnostics;
using HomeWork.Classes;
using HomeWork.Db;
using Microsoft.EntityFrameworkCore;

namespace HomeWork.Forms
{
    public partial class TablesForm : Form
    {
        internal EditorForm EditorForm;

        private DataGridViewRow _currentDataGridViewRowUsers;
        private DataGridViewRow _currentDataGridViewRowComputers;
        
        public TablesForm()
        {
            InitializeComponent();

            Type myType = typeof(User);
            foreach (var variable in myType.GetProperties())
            {
                comboBox1.Items.Add(variable.Name);
            }
        }

        internal static BindingSource PSource = new BindingSource();
        internal static BindingSource BSource = new BindingSource();

        internal void HomeWorkN1_Load(object sender, EventArgs e)
        {
            UpdateDataGrids("");
        }

        private void tabControl1_SelectTab(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Contains("Юзер"))
            {
                if (EditorForm != null)
                {
                    EditorForm.groupBox2.Hide();
                    EditorForm.groupBox1.Show();
                }

                comboBox1.Items.Clear();
                Type myType = typeof(User);
                foreach (var variable in myType.GetProperties())
                {
                    comboBox1.Items.Add(variable.Name);
                }
            }
            else
            {
                if (EditorForm != null)
                {
                    EditorForm.groupBox1.Hide();
                    EditorForm.groupBox2.Show();
                }

                comboBox1.Items.Clear();
                Type myType = typeof(Computer);
                foreach (var variable in myType.GetProperties())
                {
                    comboBox1.Items.Add(variable.Name);
                }
            }
        }

        private void HomeWorkN1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (EditorForm == null)
            {
                if (tabControl1.SelectedTab.Text.Contains("Комп"))
                {
                    Debug.WriteLine("asd123");
                    var form = new EditorForm(this, ComputersDataGridView);
                    EditorForm = form;
                    form.Show();
                }
                else if (tabControl1.SelectedTab.Text.Contains("Юзер"))
                {
                    Debug.WriteLine("zxc321");
                    var form = new EditorForm(this, UsersDataGrid);
                    EditorForm = form;
                    form.Show();
                }
            }
            else
            {
                EditorForm.Activate();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var query = comboBox1.SelectedItem.ToString();
            UpdateDataGrids(query);
        }

        internal void UpdateDataGrids(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                using var db = new MySQLDbContext();
                db.Users.Load();
                db.Computers.Load();
                ComputersDataGridView.DataSource = db.Computers.Local.ToArray();
                UsersDataGrid.DataSource = db.Users.Local.ToArray();
            }
            else
            {
                if (tabControl1.SelectedTab.Text.Contains("Юзеры"))
                {
                    using var db = new MySQLDbContext();
                    UsersDataGrid.DataSource = db.Users.OrderBy(e => EF.Property<User>(e, query)).ToArray();
                    //UsersDataGrid.DataSource = db.Users.FromSqlRaw($"SELECT * FROM Users ORDER BY {query}").ToArray();

                    db.Users.OrderBy(e => EF.Property<User>(e, query));
                }
                else
                {
                    using var db = new MySQLDbContext();
                    ComputersDataGridView.DataSource = db.Computers.OrderBy(e => EF.Property<Computer>(e, query)).ToArray();
                    //Компьютеры.DataSource = db.Computers.FromSqlRaw($"SELECT * FROM Computers ORDER BY {query}").ToArray();

                    db.Computers.OrderBy(e => EF.Property<Computer>(e, query));
                }

            }

            ComputersDataGridView.Refresh();
            ComputersDataGridView.ResetBindings();
            UsersDataGrid.Refresh();
            UsersDataGrid.ResetBindings();
        }

        private void UsersDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRowUsers == null || _currentDataGridViewRowUsers != UsersDataGrid.CurrentRow) && EditorForm != null)
            {
                var row = UsersDataGrid.CurrentRow;

                EditorForm.textBox1.Text = row.Cells[0].Value.ToString();
                EditorForm.textBox2.Text = row.Cells[1].Value.ToString();
                EditorForm.textBox3.Text = row.Cells[2].Value.ToString();

                _currentDataGridViewRowUsers = row;
            }
        }

        private void ComputersDataGridViewCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRowComputers == null || _currentDataGridViewRowComputers != ComputersDataGridView.CurrentRow) && EditorForm != null)
            {
                var row = ComputersDataGridView.CurrentRow;

                EditorForm.textBox4.Text = row.Cells[0].Value.ToString();
                EditorForm.textBox5.Text = row.Cells[1].Value.ToString();
                EditorForm.textBox6.Text = row.Cells[2].Value.ToString();
                EditorForm.textBox6.Text = row.Cells[3].Value.ToString();
                EditorForm.textBox8.Text = row.Cells[3].Value.ToString();

                _currentDataGridViewRowComputers = row;
            }
        }
    }
}