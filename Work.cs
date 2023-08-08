using System.Data;
using System.Windows.Forms;

namespace HomeWork;

public class Work
{
    internal static bool AddUser(string name, string password)
    {
        var user = new User()
        {
            Name = name,
            Password = password
        };

        var IsAdded = CheckUser(name);
        if (IsAdded) return false;

        HomeWorkN1.userList.Add(user);
        return true;
    }

    internal static bool CheckUser(string name)
    {
        return HomeWorkN1.userList.Exists(e => e.Name == name);
    }

    public static void Twinkling(Label label)
    {
        //for (int i = 0; i == 5; i++)
        //{
        //    label.Show();
        //    label.Refresh();
        //    Thread.Sleep(1000);
        //    label.Hide();
        //    label.Refresh();
        //    Thread.Sleep(500);
        //}

        //label.ForeColor = System.Drawing.Color.YellowGreen;
        //label.Text = "Ожидание";
        //label.Show();
        //label.Refresh();
    }

    public static bool TryLogin(string name, string password)
    {
        return HomeWorkN1.userList.Exists(e => e.Name == name && e.Password == password);
    }

    public static void UpdateUserTable()
    {
        var data = HomeWorkN1.dataGridView1;
        data.Rows.Clear();

        var list = HomeWorkN1.userList;

        int rowz = data.Rows.Add();
        DataGridViewRow row = data.Rows[rowz];
        row.Cells[0].Value = "Login";
        row.Cells[1].Value = "Password";

        foreach (var user in list)
        {
            int rowt = data.Rows.Add();
            DataGridViewRow row1 = data.Rows[rowt];
            row1.Cells[0].Value = user.Name;
            row1.Cells[1].Value = user.Password;
        }
    }

    public static void UpdateCompsTable()
    {
        var data = HomeWorkN1.dataGridView2;
        data.Rows.Clear();

        var list = HomeWorkN1.comps;

        int rowz = data.Rows.Add();
        DataGridViewRow row = data.Rows[rowz];
        row.Cells[0].Value = "PC Name";
        row.Cells[1].Value = "IP";
        row.Cells[2].Value = "Notation";

        foreach (var user in list)
        {
            int rowt = data.Rows.Add();
            DataGridViewRow row1 = data.Rows[rowt];
            row1.Cells[0].Value = user.PC;
            row1.Cells[1].Value = user.IP;
            row1.Cells[2].Value = user.Notation;
        }
    }

    public static bool AddComp(string PC, string IP, string Notation)
    {
        var comp = HomeWorkN1.comps.Find(e => e.PC == PC);
        if (comp != null) return false;

        var compNew = new Comp()
        {
            PC = PC,
            IP = IP,
            Notation = Notation
        };

        HomeWorkN1.comps.Add(compNew);
        return true;
    }

    public static bool DeleteComp(string PC)
    {
        var comp = HomeWorkN1.comps.Find(e => e.PC == PC);
        if (comp == null) return false;

        HomeWorkN1.comps.Remove(comp);
        return true;
    }
}