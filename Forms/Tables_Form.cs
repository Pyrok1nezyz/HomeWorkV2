using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using HomeWork.Classes;
using HomeWork.MainCOde;

namespace HomeWork
{
    public partial class HomeWorkN1 : Form
    {
        internal Editor_Form Editor_Form;

        private DataGridViewRow _currentDataGridViewRow_Users;
        private DataGridViewRow _currentDataGridViewRow_Computers;
        
        public HomeWorkN1()
        {
            InitializeComponent();

            Type myType = typeof(User);
            foreach (var VARIABLE in myType.GetProperties())
            {
                comboBox1.Items.Add(VARIABLE.Name);
            }
        }

        internal static BindingSource pSource = new BindingSource();
        internal static BindingSource bSource = new BindingSource();

        internal void HomeWorkN1_Load(object sender, EventArgs e)
        {
            UpdateDataGrids("");
        }

        private void tabControl1_SelectTab(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Contains("Юзер"))
            {
                if (Editor_Form != null)
                {
                    Editor_Form.groupBox2.Hide();
                    Editor_Form.groupBox1.Show();
                }

                comboBox1.Items.Clear();
                Type myType = typeof(User);
                foreach (var VARIABLE in myType.GetProperties())
                {
                    comboBox1.Items.Add(VARIABLE.Name);
                }
            }
            else
            {
                if (Editor_Form != null)
                {
                    Editor_Form.groupBox1.Hide();
                    Editor_Form.groupBox2.Show();
                }

                comboBox1.Items.Clear();
                Type myType = typeof(Computer);
                foreach (var VARIABLE in myType.GetProperties())
                {
                    comboBox1.Items.Add(VARIABLE.Name);
                }
            }
        }

        private void HomeWorkN1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (Editor_Form == null)
            {
                if (tabControl1.SelectedTab.Text.Contains("Комп"))
                {
                    Debug.WriteLine("asd123");
                    var form = new Editor_Form(this, ComputersDataGridView);
                    Editor_Form = form;
                    form.Show();
                }
                else if (tabControl1.SelectedTab.Text.Contains("Юзер"))
                {
                    Debug.WriteLine("zxc321");
                    var form = new Editor_Form(this, UsersDataGrid);
                    Editor_Form = form;
                    form.Show();
                }
            }
            else
            {
                Editor_Form.Activate();
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
                using (var db = new MySQLDbContext())
                {
                    db.Users.Load();
                    db.Computers.Load();
                    ComputersDataGridView.DataSource = db.Computers.Local.ToArray();
                    UsersDataGrid.DataSource = db.Users.Local.ToArray();
                }
            }
            else
            {
                if (tabControl1.SelectedTab.Text.Contains("Юзеры"))
                {
                    using (var db = new MySQLDbContext())
                    {
                        UsersDataGrid.DataSource = db.Users.OrderBy(e => EF.Property<User>(e, query)).ToArray();
                        //UsersDataGrid.DataSource = db.Users.FromSqlRaw($"SELECT * FROM Users ORDER BY {query}").ToArray();

                        db.Users.OrderBy(e => EF.Property<User>(e, query));
                    }
                }
                else
                {
                    using (var db = new MySQLDbContext())
                    {
                        ComputersDataGridView.DataSource = db.Computers.OrderBy(e => EF.Property<Computer>(e, query)).ToArray();
                        //Компьютеры.DataSource = db.Computers.FromSqlRaw($"SELECT * FROM Computers ORDER BY {query}").ToArray();

                        db.Computers.OrderBy(e => EF.Property<Computer>(e, query));
                    }
                }

            }

            ComputersDataGridView.Refresh();
            ComputersDataGridView.ResetBindings();
            UsersDataGrid.Refresh();
            UsersDataGrid.ResetBindings();
        }

        private void UsersDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRow_Users == null || _currentDataGridViewRow_Users != UsersDataGrid.CurrentRow) && Editor_Form != null)
            {
                var row = UsersDataGrid.CurrentRow;

                Editor_Form.textBox1.Text = row.Cells[0].Value.ToString();
                Editor_Form.textBox2.Text = row.Cells[1].Value.ToString();
                Editor_Form.textBox3.Text = row.Cells[2].Value.ToString();

                _currentDataGridViewRow_Users = row;
            }
        }

        private void ComputersDataGridViewCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRow_Computers == null || _currentDataGridViewRow_Computers != ComputersDataGridView.CurrentRow) && Editor_Form != null)
            {
                var row = ComputersDataGridView.CurrentRow;

                Editor_Form.textBox4.Text = row.Cells[0].Value.ToString();
                Editor_Form.textBox5.Text = row.Cells[1].Value.ToString();
                Editor_Form.textBox6.Text = row.Cells[2].Value.ToString();
                Editor_Form.textBox6.Text = row.Cells[3].Value.ToString();
                Editor_Form.textBox8.Text = row.Cells[3].Value.ToString();

                _currentDataGridViewRow_Computers = row;
            }
        }
    }
}