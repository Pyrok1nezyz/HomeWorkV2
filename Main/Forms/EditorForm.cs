using HomeWork.Classes;
using HomeWork.Db;

namespace HomeWork.Forms
{
    public partial class EditorForm : Form
    {
        private readonly TablesForm _tablesForm;

        public EditorForm(TablesForm based, DataGridView dataGridView)
        {
            _tablesForm = based;

            InitializeComponent();
            var row = dataGridView.CurrentRow;

            if (dataGridView.Name.Equals("Компьютеры"))
            {
                groupBox1.Hide();
                groupBox2.Show();

                textBox4.Text = row.Cells[0].Value.ToString();
                textBox5.Text = row.Cells[1].Value.ToString();
                textBox6.Text = row.Cells[2].Value.ToString();
                textBox7.Text = row.Cells[3].Value.ToString();
                textBox8.Text = row.Cells[3].Value.ToString();
            }
            else if (dataGridView.Name.Contains("User"))
            {
                using var db = new MySQLDbContext();
                groupBox2.Hide();
                groupBox1.Show();

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();

                comboBox1.Items.Clear();
                foreach (var computer in db.GetComputers())
                {
                    comboBox1.Items.Add(computer);
                }
            }
            else
            {
                new EditorForm(based);
            }
        }

        public EditorForm(TablesForm based)
        {
            _tablesForm = based;
            InitializeComponent();
            groupBox1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using var db = new MySQLDbContext();
            var index = db.GetUsers().OrderBy(e => e.Id).LastOrDefault()!.Id;
            var newIndex = index + 1;
            textBox1.Text = newIndex.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new MySQLDbContext())
            {
                long i = 0;
                long.TryParse(textBox1.Text, out i);

                var user = db.GetUsers().Find(e => e.Id == i);

                if (user != null)
                {
                    user.Name = textBox2.Text;
                    user.Computer = (Computer)comboBox1.SelectedItem;
                    user.Password = textBox3.Text;
                    user.IsWorker = checkBox1.Checked;

                    db.UpdateUser(user);
                    db.GetUsers();
                }
                else
                {
                    var newUser = new User(textBox2.Text, textBox3.Text)
                    {
                        Id = i,
                        IsWorker = checkBox1.Checked,
                        Computer = (Computer)comboBox1.SelectedItem
                    };

                    db.AddUser(newUser);
                    db.GetUsers();
                }
            }

            _tablesForm.HomeWorkN1_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new MySQLDbContext())
            {
                int i = 0;
                int.TryParse(textBox4.Text, out i);

                var computer = db.GetComputers().Find(e => e.Id == i);

                if (computer != null)
                {
                    computer.Name = textBox5.Text;
                    computer.Ip = textBox6.Text;
                    computer.Props = textBox7.Text;
                    computer.Notation = textBox8.Text;

                    db.UpdateComputer(computer);
                    db.GetComputers();
                }
                else
                {
                    var newCOmp = new Computer(textBox5.Text, textBox6.Text)
                    {
                        Id = i,
                        Props = textBox7.Text,
                        Notation = textBox8.Text
                    };
                    db.AddComputer(newCOmp);
                    db.GetComputers();
                }
            }

            _tablesForm.HomeWorkN1_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using var db = new MySQLDbContext();
            var index = 0;

            var lastcomp = db.GetComputers().OrderBy(e => e.Id).LastOrDefault()!;
            if (lastcomp == null)
            {
                index = 1;
            }
            else
            {
                index = lastcomp.Id + 1;
            }
            textBox4.Text = index.ToString();
        }

        private void Редактор_FormClosed(object sender, FormClosedEventArgs e)
        {
            _tablesForm.EditorForm = null;
        }
    }
}

