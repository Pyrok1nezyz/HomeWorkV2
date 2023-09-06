namespace HomeWork.Forms
{
    partial class AutorizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label4 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            ChangeText = new Button();
            PassGen = new Button();
            SuspendLayout();
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.YellowGreen;
            label4.Location = new Point(231, 280);
            label4.Name = "label4";
            label4.Size = new Size(186, 54);
            label4.TabIndex = 22;
            label4.Text = "Ожидание";
            label4.UseCompatibleTextRendering = true;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.AutoSize = true;
            button1.Location = new Point(230, 190);
            button1.Name = "button1";
            button1.Size = new Size(204, 25);
            button1.TabIndex = 20;
            button1.Text = "Логин";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top;
            textBox2.Location = new Point(336, 164);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Password";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 16;
            textBox2.UseSystemPasswordChar = true;
            textBox2.KeyDown += textBox2_KeyDown;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(207, 114);
            label1.MaximumSize = new Size(350, 0);
            label1.Name = "label1";
            label1.Size = new Size(234, 50);
            label1.TabIndex = 14;
            label1.Text = "Регистрация";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top;
            textBox1.Location = new Point(230, 164);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Login";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 15;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // ChangeText
            // 
            ChangeText.Anchor = AnchorStyles.None;
            ChangeText.AutoSize = true;
            ChangeText.Location = new Point(266, 218);
            ChangeText.Margin = new Padding(3, 2, 3, 2);
            ChangeText.Name = "ChangeText";
            ChangeText.Size = new Size(124, 25);
            ChangeText.TabIndex = 23;
            ChangeText.Text = "Registration";
            ChangeText.UseVisualStyleBackColor = true;
            ChangeText.Click += ChangeText_Click;
            // 
            // PassGen
            // 
            PassGen.Anchor = AnchorStyles.None;
            PassGen.AutoSize = true;
            PassGen.Location = new Point(230, 256);
            PassGen.Margin = new Padding(3, 2, 3, 2);
            PassGen.Name = "PassGen";
            PassGen.Size = new Size(206, 25);
            PassGen.TabIndex = 24;
            PassGen.Text = "Сгенерировать пароль";
            PassGen.UseVisualStyleBackColor = true;
            PassGen.Click += PassGen_Click;
            // 
            // AutorizationForm
            // 
            AccessibleDescription = "Введите логин";
            AccessibleName = "Тут вводить логин";
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 344);
            Controls.Add(PassGen);
            Controls.Add(ChangeText);
            Controls.Add(label4);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Margin = new Padding(3, 2, 3, 2);
            MinimizeBox = false;
            MinimumSize = new Size(718, 383);
            Name = "AutorizationForm";
            Text = "Авторизация";
            Load += Авторизация_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        internal Label label4;
        private Button button1;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox1;
        private Button ChangeText;
        private Button PassGen;
    }
}