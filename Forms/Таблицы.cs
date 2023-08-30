using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ClassLibrary_HomeWork;

namespace HomeWork
{
    public partial class HomeWorkN1 : Form
    {
        internal Редактор редактор;

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
            if (tabControl1.SelectedTab.Name.Contains("Юзер"))
            {
                if (редактор != null)
                {
                    редактор.groupBox2.Hide();
                    редактор.groupBox1.Show();
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
                if (редактор != null)
                {
                    редактор.groupBox1.Hide();
                    редактор.groupBox2.Show();
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
            if (редактор == null)
            {
                if (tabControl1.SelectedTab.Text.Contains("Комп"))
                {
                    Debug.WriteLine("asd123");
                    var form = new Редактор(this, Компьютеры);
                    редактор = form;
                    form.Show();
                }
                else if (tabControl1.SelectedTab.Text.Contains("Юзер"))
                {
                    Debug.WriteLine("zxc321");
                    var form = new Редактор(this, UsersDataGrid);
                    редактор = form;
                    form.Show();
                }
            }
            else
            {
                редактор.Activate();
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
                    Компьютеры.DataSource = db.Computers.Local.ToArray();
                    UsersDataGrid.DataSource = db.Users.Local.ToArray();
                }
            }
            else
            {
                if (tabControl1.SelectedTab.Text.Contains("Юзеры"))
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
                        Компьютеры.DataSource = db.Computers.OrderBy(e => EF.Property<Computer>(e, query)).ToArray();
                        //Компьютеры.DataSource = db.Computers.FromSqlRaw($"SELECT * FROM Computers ORDER BY {query}").ToArray();

                        db.Computers.OrderBy(e => EF.Property<Computer>(e, query));
                    }
                }

            }

            Компьютеры.Refresh();
            Компьютеры.ResetBindings();
            UsersDataGrid.Refresh();
            UsersDataGrid.ResetBindings();
        }

        private void UsersDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRow_Users == null || _currentDataGridViewRow_Users != UsersDataGrid.CurrentRow) && редактор != null)
            {
                var row = UsersDataGrid.CurrentRow;

                редактор.textBox1.Text = row.Cells[0].Value.ToString();
                редактор.textBox2.Text = row.Cells[1].Value.ToString();
                редактор.textBox3.Text = row.Cells[2].Value.ToString();

                _currentDataGridViewRow_Users = row;
            }
        }

        private void Компьютеры_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((_currentDataGridViewRow_Computers == null || _currentDataGridViewRow_Computers != Компьютеры.CurrentRow) && редактор != null)
            {
                var row = Компьютеры.CurrentRow;

                редактор.textBox4.Text = row.Cells[0].Value.ToString();
                редактор.textBox5.Text = row.Cells[1].Value.ToString();
                редактор.textBox6.Text = row.Cells[2].Value.ToString();
                редактор.textBox6.Text = row.Cells[3].Value.ToString();
                редактор.textBox8.Text = row.Cells[3].Value.ToString();

                _currentDataGridViewRow_Computers = row;
            }
        }
    }
}