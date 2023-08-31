using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeWork.Classes;
using HomeWork.MainCOde;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace HomeWork
{
    public partial class Autorization_Form : Form
    {
        public Autorization_Form()
        {
            InitializeComponent();

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (indexLayout == 0)
                {
                    var IsLogged = Work.TryLogin(textBox1.Text, textBox2.Text);

                    if (IsLogged)
                    {
                        label4.Text = "Logged";
                        label4.ForeColor = Color.Green;
                        Work.Twinkling(label4);

                        var form = new HomeWorkN1();
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
                    var IsLogged = Work.TryLogin(textBox1.Text);
                    if (!IsLogged)
                    {
                        using (var db = new MySQLDbContext())
                        {
                            var user = new User()
                            {
                                Name = textBox1.Text,
                                Password = textBox2.Text,
                                Computer = db.Computers.FirstOrDefault()
                            };

                            db.AddAsync(user);
                            db.SaveChangesAsync();
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

                var user = new User
                {
                    Name = login,
                    Password = password
                };

                using (var db = new MySQLDbContext())
                {
                    db.Users.Load();
                    db.Add(user);
                    db.SaveChanges();
                }
            }
        }

        private void Авторизация_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        int indexLayout = 0;

        private void ChangeText_Click(object sender, EventArgs e)
        {
            if (indexLayout == 0)
            {
                label1.Text = "Регистрация";
                button1.Text = "Зарегестрироваться";
                ChangeText.Text = "Login";
                indexLayout = 1;
            }
            else
            {
                label1.Text = "Логин";
                button1.Text = "Логин";
                ChangeText.Text = "Registration";
                indexLayout = 0;
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

        private int _flagLabel1 = 0;

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
