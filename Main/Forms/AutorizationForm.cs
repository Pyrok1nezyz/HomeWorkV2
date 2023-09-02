using System.Data.Entity;
using HomeWork.Classes;
using HomeWork.Db;

namespace HomeWork.Forms
{
    public partial class AutorizationForm : Form
    {
        private int _flagLabel1 = 0;
        int _indexLayout = 0;

        public AutorizationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_indexLayout == 0)
                {
                    var isLogged = Work.TryLogin(textBox1.Text, textBox2.Text);

                    if (isLogged)
                    {
                        label4.Text = "Logged";
                        label4.ForeColor = Color.Green;
                        Work.Twinkling(label4);

                        var form = new TablesForm();
                        form.Show();
                        Hide();
                    }
                    else
                    {
                        label4.Text = "Login Failed";
                        label4.ForeColor = Color.Red;
                        Work.Twinkling(label4);
                    }
                }
                else
                {
                    var isLogged = Work.TryLogin(textBox1.Text);
                    if (!isLogged)
                    {
                        using (var db = new MySQLDbContext())
                        {
                            var user = new User(textBox1.Text, textBox2.Text)
                            {
                                Computer = db.Computers.FirstOrDefault()
                            };

                            db.Add(user);
                            db.SaveChanges();
                        }

                        label4.Text = "Зарегестрирован!";
                        label4.ForeColor = Color.Green;
                        Work.Twinkling(label4);
                    }
                    else
                    {
                        label4.Text = "Register Failed";
                        label4.ForeColor = Color.Red;
                        Work.Twinkling(label4);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var password = textBox2.Text;

            if (login.ToLower() == "login" || login.ToLower().Contains("login"))
            {
                label4.Text = "Ошибка";
                label4.ForeColor = Color.Red;
                Work.Twinkling(label4);
            }
            else
            {
                label4.Text = "Добавлен";
                label4.ForeColor = Color.Green;
                Work.Twinkling(label4);

                var user = new User(login, password);

                using var db = new MySQLDbContext();
                db.Users.Load();
                db.Add(user);
                db.SaveChanges();
            }
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {

        }

        private void ChangeText_Click(object sender, EventArgs e)
        {
            if (_indexLayout == 0)
            {
                label1.Text = "Регистрация";
                button1.Text = "Зарегестрироваться";
                ChangeText.Text = "Login";
                _indexLayout = 1;
            }
            else
            {
                label1.Text = "Логин";
                button1.Text = "Логин";
                ChangeText.Text = "Registration";
                _indexLayout = 0;
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
