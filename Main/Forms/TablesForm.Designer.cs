﻿using HomeWork.Classes;

namespace HomeWork.Forms
{
    partial class TablesForm
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
            ComputersTabPage = new TabPage();
            ComputersDataGridView = new DataGridView();
            UsersTabPageInTables = new TabPage();
            UsersDataGrid = new DataGridView();
            tabControl1 = new TabControl();
            button1 = new Button();
            comboBox1 = new ComboBox();
            label1 = new Label();
            ComputersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ComputersDataGridView).BeginInit();
            UsersTabPageInTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)UsersDataGrid).BeginInit();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // ComputersTabPage
            // 
            ComputersTabPage.Controls.Add(ComputersDataGridView);
            ComputersTabPage.Location = new Point(4, 29);
            ComputersTabPage.Margin = new Padding(3, 4, 3, 4);
            ComputersTabPage.Name = "ComputersTabPage";
            ComputersTabPage.Size = new Size(976, 371);
            ComputersTabPage.TabIndex = 2;
            ComputersTabPage.Text = "Компы";
            ComputersTabPage.UseVisualStyleBackColor = true;
            // 
            // ComputersDataGridView
            // 
            ComputersDataGridView.AllowUserToOrderColumns = true;
            ComputersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            ComputersDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ComputersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ComputersDataGridView.Dock = DockStyle.Fill;
            ComputersDataGridView.Location = new Point(0, 0);
            ComputersDataGridView.Name = "ComputersDataGridView";
            ComputersDataGridView.ReadOnly = true;
            ComputersDataGridView.RightToLeft = RightToLeft.No;
            ComputersDataGridView.RowHeadersWidth = 51;
            ComputersDataGridView.RowTemplate.Height = 29;
            ComputersDataGridView.Size = new Size(976, 371);
            ComputersDataGridView.TabIndex = 0;
            ComputersDataGridView.CellEnter += ComputersDataGridViewCellEnter;
            // 
            // UsersTabPageInTables
            // 
            UsersTabPageInTables.Controls.Add(UsersDataGrid);
            UsersTabPageInTables.Location = new Point(4, 29);
            UsersTabPageInTables.Margin = new Padding(3, 4, 3, 4);
            UsersTabPageInTables.Name = "UsersTabPageInTables";
            UsersTabPageInTables.Padding = new Padding(3, 4, 3, 4);
            UsersTabPageInTables.Size = new Size(976, 371);
            UsersTabPageInTables.TabIndex = 1;
            UsersTabPageInTables.Text = "Юзеры";
            UsersTabPageInTables.UseVisualStyleBackColor = true;
            // 
            // UsersDataGrid
            // 
            UsersDataGrid.AllowUserToOrderColumns = true;
            UsersDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UsersDataGrid.Dock = DockStyle.Fill;
            UsersDataGrid.Location = new Point(3, 4);
            UsersDataGrid.Name = "UsersDataGrid";
            UsersDataGrid.ReadOnly = true;
            UsersDataGrid.RightToLeft = RightToLeft.No;
            UsersDataGrid.RowHeadersWidth = 51;
            UsersDataGrid.RowTemplate.Height = 29;
            UsersDataGrid.Size = new Size(970, 363);
            UsersDataGrid.TabIndex = 0;
            UsersDataGrid.CellEnter += UsersDataGrid_CellEnter;
            UsersDataGrid.RowEnter += UsersDataGrid_RowEnter;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(UsersTabPageInTables);
            tabControl1.Controls.Add(ComputersTabPage);
            tabControl1.Location = new Point(0, 47);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.RightToLeft = RightToLeft.Yes;
            tabControl1.RightToLeftLayout = true;
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(984, 404);
            tabControl1.TabIndex = 3;
            tabControl1.SelectedIndexChanged += tabControl1_SelectTab;
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
            // TablesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 451);
            Controls.Add(label1);
            Controls.Add(comboBox1);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            MinimumSize = new Size(1001, 498);
            Name = "TablesForm";
            RightToLeft = RightToLeft.No;
            Text = "HomeWorkN1";
            FormClosing += HomeWorkN1_FormClosing;
            Load += HomeWorkN1_Load;
            ComputersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ComputersDataGridView).EndInit();
            UsersTabPageInTables.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)UsersDataGrid).EndInit();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        internal static List<User> userList = new();
        internal static List<Computer> comps = new();
        private TabPage ComputersTabPage;
        private TabPage UsersTabPageInTables;
        private TabControl tabControl1;
        public DataGridView UsersDataGrid;
        public DataGridView ComputersDataGridView;
        private Button button1;
        private ComboBox comboBox1;
        private Label label1;
    }
}