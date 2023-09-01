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
                groupBox2.Hide();
                groupBox1.Show();

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[2].Value.ToString();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using var db = new MySQLDbContext();
            var index = db.Users.OrderBy(e => e.Id).LastOrDefault().Id;
            var newIndex = index + 1;
            textBox1.Text = newIndex.ToString();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            using (var db = new MySQLDbContext())
            {
                long i = 0;
                long.TryParse(textBox1.Text, out i);

                var user = db.Users.Find(i);

                if (user != null)
                {
                    user.Name = textBox2.Text;
                    user.Computer = db.Computers.OrderBy(e => e.Id).FirstOrDefault();
                    user.Password = textBox3.Text;

                    db.Users.Update(user);
                    await db.SaveChangesAsync();
                }
                else
                {
                    var newUser = new User()
                    {
                        Id = i,
                        Name = textBox2.Text,
                        Computer = db.Computers.OrderBy(e => e.Id).LastOrDefault(),
                        Password = textBox3.Text,
                    };

                    db.Users.Add(newUser);
                    await db.SaveChangesAsync();
                }
            }

            _tablesForm.HomeWorkN1_Load(sender, e);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            using (var db = new MySQLDbContext())
            {
                int i = 0;
                int.TryParse(textBox4.Text, out i);

                var computer = db.Computers.Find(i);

                if (computer != null)
                {
                    computer.Name = textBox5.Text;
                    computer.Ip = textBox6.Text;
                    computer.Props = textBox7.Text;
                    computer.Notation = textBox8.Text;

                    db.Update(computer);
                    await db.SaveChangesAsync();
                }
                else
                {
                    var newCOmp = new Computer()
                    {
                        Id = i,
                        Name = textBox5.Text,
                        Ip = textBox6.Text,
                        Props = textBox7.Text,
                        Notation = textBox8.Text
                    };
                    db.Computers.Add(newCOmp);
                    await db.SaveChangesAsync();
                }
            }

            _tablesForm.HomeWorkN1_Load(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using var db = new MySQLDbContext();
            var lastcomp = db.Computers.OrderBy(e => e.Id).LastOrDefault();
            var index = lastcomp.Id + 1;

            textBox4.Text = index.ToString();
        }

        private void Редактор_FormClosed(object sender, FormClosedEventArgs e)
        {
            _tablesForm.EditorForm = null;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}

