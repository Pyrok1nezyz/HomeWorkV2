using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace HomeWork
{
    public partial class HomeWorkN1 : Form
    {
        internal Редактор редактор;
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

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            var row = UsersDataGrid.CurrentRow;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void userBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
                    Компьютеры.DataSource = db.Computers.Local.ToBindingList();
                    UsersDataGrid.DataSource = db.Users.Local.ToBindingList();
                }
            }
            else
            {
                if (tabControl1.SelectedTab.Text.Contains("Юзеры"))
                {
                    using (var db = new WorkApp())
                    {
                        UsersDataGrid.DataSource = db.Users.OrderBy(e => EF.Property<User>(e, query)).ToArray();
                    }
                }
                else
                {
                    using (var db = new WorkApp())
                    {
                        Компьютеры.DataSource = db.Computers.OrderBy(e => EF.Property<Computer>(e, query)).ToArray();
                    }
                }

            }

            Компьютеры.Refresh();
            Компьютеры.ResetBindings();
            UsersDataGrid.Refresh();
            UsersDataGrid.ResetBindings();
        }
    }
}