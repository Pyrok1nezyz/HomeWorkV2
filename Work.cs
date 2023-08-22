﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace HomeWork;

public class Work
{
    public static async void Twinkling(Label label)
    {
        for (int i = 0; i < 6; i++)
        {
            label.Hide();
            await Task.Delay(500);
            label.Show();
            await Task.Delay(3 * 500);
        }
    }

    public static bool TryLogin(string name, string password)
    {
        using (var db = new HomeWorkN1.WorkApp())
        {
            db.Users.Load();
            var answer = db.Users.Any(e => e.Name.Equals(name) && e.Password.Equals(password));
            return answer;
        }
    }

    public static bool TryLogin(string name)
    {
        using (var db = new HomeWorkN1.WorkApp())
        {
            db.Users.Load();
            return db.Users.Any(e => e.Name == name);
        }
    }

    //internal void UpdateUsersTable(DataGridView dgv, DataSet dataSet)
    //{
    //    using (var db = new HomeWorkN1.WorkApp())
    //    {
    //        db.Users.Load();
    //        HomeWorkN1.pSource.DataSource = db.Users.Local.ToBindingList();
    //    }

    //}

    //internal static void UpdateComputersTable()
    //{
    //    using (var db = new HomeWorkN1.WorkApp())
    //    {
    //        db.Computers.Load();
    //        HomeWorkN1.bSource.DataSource = db.Computers.Local.ToBindingList();
    //    }

    //}
}