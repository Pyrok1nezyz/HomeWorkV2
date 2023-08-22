using System.Data;
using System.Text.Json;
using System.Reflection;

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
            Компы = new TabPage();
            Компьютеры = new DataGridView();
            Юзеры = new TabPage();
            UsersDataGrid = new DataGridView();
            tabControl1 = new TabControl();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            Компы.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Компьютеры).BeginInit();
            Юзеры.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UsersDataGrid).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // Компы
            // 
            Компы.Controls.Add(Компьютеры);
            Компы.Location = new Point(4, 29);
            Компы.Margin = new Padding(3, 4, 3, 4);
            Компы.Name = "Компы";
            Компы.Size = new Size(976, 371);
            Компы.TabIndex = 2;
            Компы.Text = "Компы";
            Компы.UseVisualStyleBackColor = true;
            // 
            // Компьютеры
            // 
            Компьютеры.AllowUserToOrderColumns = true;
            Компьютеры.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Компьютеры.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            Компьютеры.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Компьютеры.Dock = DockStyle.Fill;
            Компьютеры.Location = new Point(0, 0);
            Компьютеры.Name = "Компьютеры";
            Компьютеры.RightToLeft = RightToLeft.No;
            Компьютеры.RowHeadersWidth = 51;
            Компьютеры.RowTemplate.Height = 29;
            Компьютеры.Size = new Size(976, 371);
            Компьютеры.TabIndex = 0;
            Компьютеры.CellContentClick += dataGridView2_CellContentClick_1;
            // 
            // Юзеры
            // 
            Юзеры.Controls.Add(UsersDataGrid);
            Юзеры.Location = new Point(4, 29);
            Юзеры.Margin = new Padding(3, 4, 3, 4);
            Юзеры.Name = "Юзеры";
            Юзеры.Padding = new Padding(3, 4, 3, 4);
            Юзеры.Size = new Size(976, 371);
            Юзеры.TabIndex = 1;
            Юзеры.Text = "Юзеры";
            Юзеры.UseVisualStyleBackColor = true;
            // 
            // UsersDataGrid
            // 
            UsersDataGrid.AllowUserToOrderColumns = true;
            UsersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UsersDataGrid.Dock = DockStyle.Fill;
            UsersDataGrid.Location = new Point(3, 4);
            UsersDataGrid.Name = "UsersDataGrid";
            UsersDataGrid.RightToLeft = RightToLeft.No;
            UsersDataGrid.RowHeadersWidth = 51;
            UsersDataGrid.RowTemplate.Height = 29;
            UsersDataGrid.Size = new Size(970, 363);
            UsersDataGrid.TabIndex = 0;
            UsersDataGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(Юзеры);
            tabControl1.Controls.Add(Компы);
            tabControl1.Location = new Point(0, 47);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(984, 404);
            tabControl1.TabIndex = 3;
            tabControl1.TabIndexChanged += tabControl1_SelectTab;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Top;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(983, 28);
            button1.TabIndex = 4;
            button1.Text = "Редактор";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(102, 34);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 5;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(4, 37);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 6;
            label1.Text = "Сортировка";
            // 
            // HomeWorkN1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 451);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Name = "HomeWorkN1";
            RightToLeft = RightToLeft.No;
            Text = "HomeWorkN1";
            FormClosing += HomeWorkN1_FormClosing;
            Load += HomeWorkN1_Load;
            Компы.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Компьютеры).EndInit();
            Юзеры.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)UsersDataGrid).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal static List<User> userList = new();
        internal static List<Computer> comps = new();
        private TabPage Компы;
        private TabPage Юзеры;
        private TabControl tabControl1;
        public DataGridView UsersDataGrid;
        public DataGridView Компьютеры;
        private Button button1;
        private ComboBox comboBox1;
        private Label label1;
    }
}