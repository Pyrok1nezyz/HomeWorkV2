using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using HomeWork.Classes;
using HomeWork.Db;
using MySql.Data.MySqlClient;

namespace HomeWork.Forms
{
    public partial class TablesForm : Form
    {
        internal EditorForm? EditorForm;

        private DataGridViewRow? _currentDataGridViewRowUsers;
        private DataGridViewRow? _currentDataGridViewRowComputers;

        public TablesForm()
        {
            InitializeComponent();

            Type myType = typeof(User);
            foreach (var variable in myType.GetProperties())
            {
                comboBox1.Items.Add(variable.Name);
            }

            UpdateStatsLabels();
        }

        internal static BindingSource PSource = new BindingSource();
        internal static BindingSource BSource = new BindingSource();

        internal void HomeWorkN1_Load(object sender, EventArgs e)
        {
            UpdateDataGrids("");
        }

        private void tabControl1_SelectTab(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name.Contains("User"))
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
                if (tabControl1.SelectedTab.Text == ("Компы"))
                {
                    Debug.WriteLine("asd123");
                    var form = new EditorForm(this, ComputersDataGridView);
                    EditorForm = form;
                    form.Show();
                }
                else if (tabControl1.SelectedTab.Text == ("Юзеры"))
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
            var query = comboBox1.SelectedItem.ToString()!;
            UpdateDataGrids(query);
        }

        internal void UpdateDataGrids(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                using var db = new MySQLDbContext();
                db.GetUsers();
                db.GetComputers();
                ComputersDataGridView.DataSource = db.GetComputers();
                UsersDataGrid.DataSource = db.GetUsers();
            }
            else
            {
                if (tabControl1.SelectedTab.Text == ("Юзеры"))
                {
                    using var db = new MySQLDbContext();

                    switch (query)
                    {
                        default:
                            {
                                UsersDataGrid.DataSource = db.GetUsers().OrderBy(e => e.Id).ToList();
                                break;
                            }

                        case "Name":
                            {
                                UsersDataGrid.DataSource = db.GetUsers().OrderBy(e => e.Name).ToList();
                                break;
                            }

                        case "Password":
                            {
                                UsersDataGrid.DataSource = db.GetUsers().OrderBy(e => e.Password).ToList();
                                break;
                            }

                        case "Computer":
                            {
                                UsersDataGrid.DataSource = db.GetUsers().OrderBy(e => e.Computer).ToList();
                                break;
                            }
                    }

                    //UsersDataGrid.DataSource = db.Users.FromSqlRaw($"SELECT * FROM Users ORDER BY {query}").ToArray();
                }
                else if (tabControl1.SelectedTab.Text == "Компы")
                {
                    using var db = new MySQLDbContext();

                    switch (query)
                    {
                        default:
                            {
                                ComputersDataGridView.DataSource = db.GetComputers().OrderBy(e => e.Id).ToList();
                                break;
                            }

                        case "Name":
                            {
                                ComputersDataGridView.DataSource = db.GetComputers().OrderBy(e => e.Name).ToList();
                                break;
                            }

                        case "Ip":
                            {
                                ComputersDataGridView.DataSource = db.GetComputers().OrderBy(e => e.Ip).ToList();
                                break;
                            }

                        case "Props":
                            {
                                ComputersDataGridView.DataSource = db.GetComputers().OrderBy(e => e.Props).ToList();
                                break;
                            }

                        case "Notation":
                            {
                                ComputersDataGridView.DataSource = db.GetComputers().OrderBy(e => e.Notation).ToList();
                                break;
                            }
                    }


                    //ComputersDataGridView.DataSource = db.Computers.OrderBy(e => EF.Property<Computer>(e, query)).ToArray();
                    //Компьютеры.DataSource = db.Computers.FromSqlRaw($"SELECT * FROM Computers ORDER BY {query}").ToArray();

                    //db.Computers.OrderBy(e => EF.Property<Computer>(e, query));
                }


            }

            //ComputersDataGridView.Refresh();
            //ComputersDataGridView.ResetBindings();
            //UsersDataGrid.Refresh();
            //UsersDataGrid.ResetBindings();
        }

        private void UsersDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ComputersDataGridViewCellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRowComputers == null || _currentDataGridViewRowComputers != ComputersDataGridView.CurrentRow) && EditorForm != null)
            {
                var row = ComputersDataGridView.CurrentRow;

                if (row == null) return;

                EditorForm.textBox4.Text = row.Cells[0].Value.ToString();
                EditorForm.textBox5.Text = row.Cells[1].Value.ToString();
                EditorForm.textBox6.Text = row.Cells[2].Value.ToString();
                EditorForm.textBox7.Text = row.Cells[3].Value.ToString();
                EditorForm.textBox8.Text = row.Cells[4].Value.ToString();

                _currentDataGridViewRowComputers = row;
            }
        }

        private void UsersDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRowUsers == null || _currentDataGridViewRowUsers != UsersDataGrid.CurrentRow) && EditorForm != null)
            {
                var row = UsersDataGrid.CurrentRow;
                using var db = new MySQLDbContext();

                if (row == null) return;

                EditorForm.textBox1.Text = row.Cells[0].Value.ToString();
                EditorForm.textBox2.Text = row.Cells[1].Value.ToString();
                EditorForm.textBox3.Text = row.Cells[2].Value.ToString();

                //list of computers
                EditorForm.comboBox1.Items.Clear();
                foreach (var computer in db.GetComputers())
                {
                    EditorForm.comboBox1.Items.Add(computer);
                }
                var comp = (Computer)row.Cells[3].Value;

                if (comp != null)
                {
                    EditorForm.comboBox1.SelectedIndex = comp.Id - 1;
                    EditorForm.comboBox1.Refresh();
                }

                _currentDataGridViewRowUsers = row;
            }
        }

        internal void UpdateStatsLabels()
        {
            using (var db = new MySQLDbContext())
            {
                var query = "";
                var cmd = new MySqlCommand(query, db.connection);
                int n = 0;
                int rows = 0;

                query = "SELECT COUNT(*) FROM Users";
                cmd = new MySqlCommand(query, db.connection);
                var count = cmd.ExecuteScalar().ToString();
                int.TryParse(count, out n);
                rows = rows + n;
                statLabel_countOfUsers_text.Text = count;

                query = "SELECT COUNT(*) FROM Computers";
                cmd = new MySqlCommand(query, db.connection);
                count = cmd.ExecuteScalar().ToString();
                int.TryParse(count, out n);
                rows = rows + n;
                statLabel_countOfComputers_text.Text = count;

                statlabel_countOfRows_text.Text = rows.ToString();
            }
        }
    }
}