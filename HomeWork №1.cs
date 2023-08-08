using System.Text.Json;
using System.Text.Json.Serialization;

namespace HomeWork
{
    public partial class HomeWorkN1 : Form
    {
        public HomeWorkN1()
        {
            InitializeComponent();
            groupBox1.Hide();

            var text = File.ReadAllText("Users.json");
            var list = JsonSerializer.Deserialize<List<User>>(text);
            if (list != null) userList.AddRange(list);

            var text2 = File.ReadAllText("Comps.json");
            var list2 = JsonSerializer.Deserialize<List<Comp>>(text2);
            if (list2 != null) comps.AddRange(list2);
        }

        ~HomeWorkN1()
        {
            var text = JsonSerializer.Serialize(userList);
            File.WriteAllText("Users.json", text);

            var text2 = JsonSerializer.Serialize(comps);
            File.WriteAllText("Comps.json", text2);
        }

        private void HomeWorkN1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var IsLogged = Work.TryLogin(textBox1.Text, textBox2.Text);

            if (IsLogged)
            {
                groupBox1.Show();
                label4.Text = "Logged";
                label4.ForeColor = Color.Green;
                label4.Refresh();
                Work.Twinkling(label4);
                Work.UpdateUserTable();
            }
            else
            {
                MessageBox.Show("Ошибка");
                label4.Text = "Ошибка";
                label4.ForeColor = Color.Red;
                Work.Twinkling(label4);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var login = textBox3.Text;
            var password = textBox4.Text;

            if (login.ToLower() == "login" || login.ToLower().Contains("login"))
            {
                label4.Text = "Ошибка";
                label4.ForeColor = Color.Red;
                label4.Refresh();
                Work.Twinkling(label4);
            }
            else
            {
                var IsAddSuccessful = Work.AddUser(login, password);
                if (IsAddSuccessful)
                {
                    label4.Text = "Добавлен";
                    label4.ForeColor = Color.Green;
                    label4.Refresh();
                    Work.Twinkling(label4);
                }
                else
                {
                    label4.Text = "Ошибка";
                    label4.ForeColor = Color.Red;
                    label4.Refresh();
                    Work.Twinkling(label4);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var answer = Work.AddComp(textBox5.Text, textBox6.Text, textBox7.Text);
            if (answer)
            {
                label4.Text = "Добавлен";
                label4.ForeColor = Color.Green;
                label4.Refresh();

                Work.Twinkling(label4);
            }
            else
            {
                MessageBox.Show("Ошибка");
                label4.Text = "Ошибка";
                label4.ForeColor = Color.Red;
                label4.Refresh();

                Work.Twinkling(label4);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var answer = Work.DeleteComp(textBox5.Text);

            if (answer)
            {
                label4.Text = "Удален";
                label4.ForeColor = Color.Green;
                label4.Refresh();

                Work.Twinkling(label4);
            }
            else
            {
                MessageBox.Show("Ошибка");
                label4.Text = "Ошибка";
                label4.ForeColor = Color.Red;
                label4.Refresh();

                Work.Twinkling(label4);
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Work.UpdateCompsTable();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}