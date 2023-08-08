using System.Data;
using System.Text.Json;

namespace HomeWork
{
    partial class HomeWorkN1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Регистрация = new TabPage();
            label4 = new Label();
            groupBox1 = new GroupBox();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            label2 = new Label();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            Юзеры = new TabPage();
            dataGridView1 = new DataGridView();
            User = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            Компы = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            dataGridView2 = new DataGridView();
            PC = new DataGridViewTextBoxColumn();
            IP = new DataGridViewTextBoxColumn();
            Notation = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            Регистрация.SuspendLayout();
            groupBox1.SuspendLayout();
            Юзеры.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            Компы.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Регистрация);
            tabControl1.Controls.Add(Юзеры);
            tabControl1.Controls.Add(Компы);
            tabControl1.Location = new Point(14, 16);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(773, 419);
            tabControl1.TabIndex = 3;
            // 
            // Регистрация
            // 
            Регистрация.Controls.Add(label4);
            Регистрация.Controls.Add(groupBox1);
            Регистрация.Controls.Add(button2);
            Регистрация.Controls.Add(button1);
            Регистрация.Controls.Add(textBox4);
            Регистрация.Controls.Add(textBox3);
            Регистрация.Controls.Add(label3);
            Регистрация.Controls.Add(textBox2);
            Регистрация.Controls.Add(label1);
            Регистрация.Controls.Add(textBox1);
            Регистрация.Location = new Point(4, 29);
            Регистрация.Margin = new Padding(3, 4, 3, 4);
            Регистрация.Name = "Регистрация";
            Регистрация.Padding = new Padding(3, 4, 3, 4);
            Регистрация.Size = new Size(765, 386);
            Регистрация.TabIndex = 0;
            Регистрация.Text = "Логин";
            Регистрация.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.YellowGreen;
            label4.Location = new Point(18, 309);
            label4.Name = "label4";
            label4.Size = new Size(232, 67);
            label4.TabIndex = 13;
            label4.Text = "Ожидание";
            label4.UseCompatibleTextRendering = true;
            label4.Click += label4_Click;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Gainsboro;
            groupBox1.Controls.Add(button5);
            groupBox1.Controls.Add(button4);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox5);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox7);
            groupBox1.Location = new Point(271, 8);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(486, 365);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Enter += groupBox1_Enter;
            // 
            // button5
            // 
            button5.Location = new Point(186, 174);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(86, 31);
            button5.TabIndex = 15;
            button5.Text = "Refresh";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click_1;
            // 
            // button4
            // 
            button4.Location = new Point(233, 135);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(86, 31);
            button4.TabIndex = 14;
            button4.Text = "Delete";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(141, 135);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(86, 31);
            button3.TabIndex = 13;
            button3.Text = "Add";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.FlatStyle = FlatStyle.Flat;
            label2.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(141, 13);
            label2.Name = "label2";
            label2.Size = new Size(231, 46);
            label2.TabIndex = 13;
            label2.Text = "Comp Control";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Click += label2_Click_1;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(65, 81);
            textBox5.Margin = new Padding(3, 4, 3, 4);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(114, 27);
            textBox5.TabIndex = 7;
            textBox5.Text = "PC Name";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(186, 80);
            textBox6.Margin = new Padding(3, 4, 3, 4);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(114, 27);
            textBox6.TabIndex = 8;
            textBox6.Text = "IP";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(307, 80);
            textBox7.Margin = new Padding(3, 4, 3, 4);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(114, 27);
            textBox7.TabIndex = 9;
            textBox7.Text = "Notation";
            // 
            // button2
            // 
            button2.Location = new Point(18, 275);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(114, 31);
            button2.TabIndex = 11;
            button2.Text = "Registration";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(18, 127);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(86, 31);
            button1.TabIndex = 10;
            button1.Text = "Login";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(139, 236);
            textBox4.Margin = new Padding(3, 4, 3, 4);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(114, 27);
            textBox4.TabIndex = 6;
            textBox4.Text = "Password";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(18, 236);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(114, 27);
            textBox3.TabIndex = 5;
            textBox3.Text = "Login";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(7, 165);
            label3.Name = "label3";
            label3.Size = new Size(295, 62);
            label3.TabIndex = 4;
            label3.Text = "Регистрация";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(139, 75);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(114, 27);
            textBox2.TabIndex = 2;
            textBox2.Text = "Password";
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(7, 4);
            label1.Name = "label1";
            label1.Size = new Size(159, 62);
            label1.TabIndex = 0;
            label1.Text = "Логин";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(18, 75);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 27);
            textBox1.TabIndex = 1;
            textBox1.Text = "Login";
            textBox1.TextChanged += textBox1_TextChanged_1;
            // 
            // Юзеры
            // 
            Юзеры.Controls.Add(dataGridView1);
            Юзеры.Location = new Point(4, 29);
            Юзеры.Margin = new Padding(3, 4, 3, 4);
            Юзеры.Name = "Юзеры";
            Юзеры.Padding = new Padding(3, 4, 3, 4);
            Юзеры.Size = new Size(765, 386);
            Юзеры.TabIndex = 1;
            Юзеры.Text = "Юзеры";
            Юзеры.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { User, Password });
            dataGridView1.Location = new Point(6, 7);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(753, 372);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // User
            // 
            User.Frozen = true;
            User.HeaderText = "User";
            User.MinimumWidth = 6;
            User.Name = "User";
            User.ReadOnly = true;
            User.Width = 125;
            // 
            // Password
            // 
            Password.Frozen = true;
            Password.HeaderText = "Password";
            Password.MinimumWidth = 6;
            Password.Name = "Password";
            Password.ReadOnly = true;
            Password.Width = 125;
            // 
            // Компы
            // 
            Компы.Controls.Add(tableLayoutPanel2);
            Компы.Location = new Point(4, 29);
            Компы.Margin = new Padding(3, 4, 3, 4);
            Компы.Name = "Компы";
            Компы.Size = new Size(765, 386);
            Компы.TabIndex = 2;
            Компы.Text = "Компы";
            Компы.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(dataGridView2, 3, 1);
            tableLayoutPanel2.Location = new Point(3, 4);
            tableLayoutPanel2.Margin = new Padding(3, 4, 3, 4);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(757, 373);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { PC, IP, Notation });
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.RowTemplate.Height = 29;
            dataGridView2.Size = new Size(754, 370);
            dataGridView2.TabIndex = 0;
            // 
            // PC
            // 
            PC.Frozen = true;
            PC.HeaderText = "PC";
            PC.MinimumWidth = 6;
            PC.Name = "PC";
            PC.ReadOnly = true;
            PC.Width = 125;
            // 
            // IP
            // 
            IP.Frozen = true;
            IP.HeaderText = "IP";
            IP.MinimumWidth = 6;
            IP.Name = "IP";
            IP.ReadOnly = true;
            IP.Width = 125;
            // 
            // Notation
            // 
            Notation.Frozen = true;
            Notation.HeaderText = "Notation";
            Notation.MinimumWidth = 6;
            Notation.Name = "Notation";
            Notation.ReadOnly = true;
            Notation.Width = 125;
            // 
            // HomeWorkN1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(tabControl1);
            Name = "HomeWorkN1";
            Text = "HomeWorkN1";
            Load += HomeWorkN1_Load;
            tabControl1.ResumeLayout(false);
            Регистрация.ResumeLayout(false);
            Регистрация.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            Юзеры.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            Компы.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        internal static List<User> userList = new();
        internal static List<Comp> comps = new();
        private TabControl tabControl1;
        private TabPage Регистрация;
        private TabPage Юзеры;
        private TabPage Компы;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label3;
        private Button button2;
        private Button button1;
        private TextBox textBox7;
        private TextBox textBox6;
        private GroupBox groupBox1;
        private Label label2;
        private Button button4;
        private Button button3;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label4;
        private Button button5;
        private DataGridViewTextBoxColumn User;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn PC;
        private DataGridViewTextBoxColumn IP;
        private DataGridViewTextBoxColumn Notation;
        public static DataGridView dataGridView1;
        public static DataGridView dataGridView2;
    }
}