using System.Text;
using HomeWork.Classes;
using HomeWork.Db;

namespace HomeWork.Forms
{
    public partial class AutorizationForm : Form
    {
        private int _flagLabel1 = 0;
        int _indexLayout = 0;
        Random rnd = new Random();


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
                                Computer = db.GetComputers().FirstOrDefault()
                            };

                            db.AddUser(user);
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
                db.AddUser(user);
                db.GetUsers();
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

        private async void PassGen_Click(object sender, EventArgs e)
        {
            textBox2.Text = await GetRandomPassword();
            textBox2.UseSystemPasswordChar = false;
        }

        private async Task<string> GetRandomPassword()
        {
            const string check = "|!@#$%^&*/'`~";
            const string check2 = "abcdefghijklmopqrstuvwxyz";
            const string check3 = "ABCDEFGHIJKLMOPQRSTUYWXYZ";

            StringBuilder password = new StringBuilder();

            for (int i = 0; i < rnd.Next(8, 17); i++)
            {
                var symbol = Convert.ToChar(rnd.Next(33, 127));
                password.Append(symbol);
            }

            var newpass = password.ToString();

            //проверка на наличие спец символа
            var IsHaveSpecialSymbol = false;
            //проверка на наличие литера в верхнем регистре
            var IsHaveBigLetter = false;
            //проверка на наличие литера в нижнем регистре
            var IsHaveSmallLetter = false;

            foreach (var letter in newpass)
            {
                foreach (var c1 in check)
                {
                    if (letter == c1)
                    {
                        IsHaveSpecialSymbol = true;
                        continue;
                    }
                }

                foreach (var c2 in check2)
                {
                    if (letter == c2)
                    {
                        IsHaveSmallLetter = true;
                        continue;
                    }
                }

                foreach (var c3 in check3)
                {
                    if (letter == c3)
                    {
                        IsHaveBigLetter = true;
                        continue;
                    }
                }
            }

            if (IsHaveSmallLetter && IsHaveBigLetter && IsHaveSpecialSymbol)
            {
                return newpass;

            }
            else
            {
                return await GetRandomPassword();
            }
        }
    }
}
