namespace HomeWork.Db;

public class Work
{
    public static async void Twinkling(Label label)
    {
        for (var i = 0; i < 6; i++)
        {
            label.Hide();
            await Task.Delay(500);
            label.Show();
            await Task.Delay(3 * 500);
        }
    }

    public static bool TryLogin(string name, string password)
    {
        using (var db = new MySQLDbContext())
        {
            foreach (var user in db.GetUsers())
            {
                if (user.Name == name && user.Password == password)
                {
                    return true;
                }
            }
        }

        return false;

        //var query = db.Users.Find(user);
        //var answer = db.Users.FromSql($"SELECT * FROM Users WHERE Name = {name} AND Password = {password};");
        //var answer = db.Users.Any(e => EF.Functions.Collate(e.Name, "SQL_Latin1_General_CP1_CS_AS") == name && EF.Functions.Collate(e.Password, "SQL_Latin1_General_CP1_CS_AS") == password);
    }

    public static bool TryLogin(string name)
    {
        using var db = new MySQLDbContext();
        return db.GetUsers().Exists(e => e.Name == name);
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