using HomeWork.Db;

namespace HomeWork;

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
    }

    public static bool TryLogin(string name)
    {
        using var db = new MySQLDbContext();
        return db.GetUsers().Exists(e => e.Name == name);
    }
}