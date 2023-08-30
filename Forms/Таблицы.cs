using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ClassLibrary_HomeWork;

namespace HomeWork
{
    public partial class HomeWorkN1 : Form
    {
        internal �������� ��������;

        private DataGridViewRow _currentDataGridViewRow_Users;
        private DataGridViewRow _currentDataGridViewRow_Computers;
        public partial class WorkApp : DbContext
        {

            public WorkApp()
            {
                Database.EnsureCreated();
            }

            public WorkApp(DbContextOptions<WorkApp> options)
            : base(options)
            {
            }

            public DbSet<User> Users { get; set; } = null!;
            public DbSet<Computer> Computers { get; set; } = null!;

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseMySql("server=localhost;user=root;password=telega123;database=usersdb;", new MySqlServerVersion(new Version(8, 1, 0)));


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            }

            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        }
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
            if (tabControl1.SelectedTab.Name.Contains("����"))
            {
                if (�������� != null)
                {
                    ��������.groupBox2.Hide();
                    ��������.groupBox1.Show();
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
                if (�������� != null)
                {
                    ��������.groupBox1.Hide();
                    ��������.groupBox2.Show();
                }

                comboBox1.Items.Clear();
                Type myType = typeof(Computer);
                foreach (var VARIABLE in myType.GetProperties())
                {
                    comboBox1.Items.Add(VARIABLE.Name);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HomeWorkN1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (�������� == null)
            {
                if (tabControl1.SelectedTab.Text.Contains("����"))
                {
                    Debug.WriteLine("asd123");
                    var form = new ��������(this, ����������);
                    �������� = form;
                    form.Show();
                }
                else if (tabControl1.SelectedTab.Text.Contains("����"))
                {
                    Debug.WriteLine("zxc321");
                    var form = new ��������(this, UsersDataGrid);
                    �������� = form;
                    form.Show();
                }
            }
            else
            {
                ��������.Activate();
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
                using (var db = new WorkApp())
                {
                    db.Users.Load();
                    db.Computers.Load();
                    ����������.DataSource = db.Computers.Local.ToArray();
                    UsersDataGrid.DataSource = db.Users.Local.ToArray();
                }
            }
            else
            {
                if (tabControl1.SelectedTab.Text.Contains("�����"))
                {
                    using (var db = new WorkApp())
                    {
                        UsersDataGrid.DataSource = db.Users.OrderBy(e => EF.Property<User>(e, query)).ToArray();
                        //UsersDataGrid.DataSource = db.Users.FromSqlRaw($"SELECT * FROM Users ORDER BY {query}").ToArray();

                        db.Users.OrderBy(e => EF.Property<User>(e, query));
                    }
                }
                else
                {
                    using (var db = new WorkApp())
                    {
                        ����������.DataSource = db.Computers.OrderBy(e => EF.Property<Computer>(e, query)).ToArray();
                        //����������.DataSource = db.Computers.FromSqlRaw($"SELECT * FROM Computers ORDER BY {query}").ToArray();

                        db.Computers.OrderBy(e => EF.Property<Computer>(e, query));
                    }
                }

            }

            ����������.Refresh();
            ����������.ResetBindings();
            UsersDataGrid.Refresh();
            UsersDataGrid.ResetBindings();
        }

        private void UsersDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRow_Users == null || _currentDataGridViewRow_Users != UsersDataGrid.CurrentRow) && �������� != null)
            {
                var row = UsersDataGrid.CurrentRow;

                ��������.textBox1.Text = row.Cells[0].Value.ToString();
                ��������.textBox2.Text = row.Cells[1].Value.ToString();
                ��������.textBox3.Text = row.Cells[2].Value.ToString();

                _currentDataGridViewRow_Users = row;
            }
        }

        private void ����������_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRow_Computers == null || _currentDataGridViewRow_Computers != ����������.CurrentRow) && �������� != null)
            {
                var row = ����������.CurrentRow;

                ��������.textBox4.Text = row.Cells[0].Value.ToString();
                ��������.textBox5.Text = row.Cells[1].Value.ToString();
                ��������.textBox6.Text = row.Cells[2].Value.ToString();
                ��������.textBox6.Text = row.Cells[3].Value.ToString();
                ��������.textBox8.Text = row.Cells[3].Value.ToString();

                _currentDataGridViewRow_Computers = row;
            }
        }
    }
}