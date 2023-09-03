using HomeWork.Classes;
using MySql.Data.MySqlClient;
using Computer = HomeWork.Classes.Computer;

namespace HomeWork.Db;

public sealed class MySQLDbContext : IDisposable
{
    private MySqlConnection connection;
    public MySQLDbContext()
    {
        string connectionString = "server=localhost;user=root;password=telega123;database=usersdb;";
        connection = GetConnection(connectionString);
        connection.Open();
    }

    public MySqlConnection GetConnection(string connectionString)
    {
        return new MySqlConnection(connectionString);
    }

    public List<User> GetUsers(MySqlConnection connection)
    {
        var query = "SELECT * FROM Users";
        var cmd = new MySqlCommand(query, connection);

        var list = new List<User>();
        var listComputers = GetComputers();

        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    User user;

                    if (!reader.IsDBNull(3))
                    {
                        user = new User(reader.GetString(1), reader.GetString(2))
                        {
                            Id = reader.GetInt64(0),
                            Computer = listComputers.Find(e => e.Id == reader.GetInt32(3))
                        };
                    }
                    else
                    {
                        user = new User(reader.GetString(1), reader.GetString(2))
                        {
                            Id = reader.GetInt64(0),
                        };
                    }

                    list.Add(user);
                }
            }
        }

        return list;
    }

    public List<User> GetUsers()
    {
        return GetUsers(this.connection);
    }

    public List<Computer> GetComputers(MySqlConnection connection)
    {
        var query = "SELECT * FROM Computers";
        var cmd = new MySqlCommand(query, connection);

        var list = new List<Computer>();

        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Computer computer;

                        computer = new Computer(reader.GetString(1), reader.GetString(2))
                        {
                            Id = reader.GetInt32(0),
                            Notation = reader.GetString(3),
                            Props = reader.GetString(4)
                        };

                    list.Add(computer);
                }
            }
        }

        return list;
    }

    public List<Computer> GetComputers()
    {
        return GetComputers(this.connection);
    }

    public int AddUser(User user, MySqlConnection connection)
    {
        var query = user.Computer != null 
            ? $"INSERT INTO Users (Name, Password, ComputerId) VALUES ('{user.Name}','{user.Password}','{user.Computer.Id}');" 
            : $"INSERT INTO Users (Name, Password) VALUES ('{user.Name}','{user.Password}');";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        var IsAdded = cmd.ExecuteNonQuery();
        if (IsAdded == 0) throw new Exception("Не удалось добавить юзера в таблицу Users");
        return cmd.ExecuteNonQuery();
    }

    public int AddUser(User user)
    {
        return AddUser(user, this.connection);
    }

    public int AddComputer(Computer computer, MySqlConnection connection)
    {
        var query =
            $"INSERT INTO Computers (Name, Ip, Props, Notation) VALUES ('{computer.Name}','{computer.Ip}','{computer.Props}','{computer.Notation}');";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        var IsAdded = cmd.ExecuteNonQuery();
        if (IsAdded == 0) throw new Exception("Не удалось добавить компьютер в таблицу Computers");
        return IsAdded;
    }

    public int AddComputer(Computer computer)
    {
        return AddComputer(computer, this.connection);
    }

    public int UpdateUser(User user, MySqlConnection connection)
    {
        var query = user.Computer != null
            ? $"UPDATE Users SET Name={user.Name},Password={user.Password},ComputerId={user.Computer.Id} WHERE Id={user.Id}"
            : $"UPDATE Users SET Name={user.Name},Password={user.Password} WHERE Id={user.Id}";
        var cmd = new MySqlCommand(query, connection);
        var IsUpdated = cmd.ExecuteNonQuery();
        if (IsUpdated == 0)
            throw new Exception($"Не удалось обновить User (UserId = {user.Id}, UserName = {user.Name})");
        return IsUpdated;
    }

    public int UpdateUser(User user)
    {
        return UpdateUser(user, this.connection);
    }

    public int UpdateComputer(Computer computer, MySqlConnection connection)
    {
        var query =
            $"UPDATE Computers SET Name={computer.Name},Ip={computer.Ip},Notation={computer.Notation},Props={computer.Props} WHERE Id={computer.Id}";
        var cmd = new MySqlCommand(query, connection);
        var IsUpdated = cmd.ExecuteNonQuery();
        if (IsUpdated == 0)
            throw new Exception(
                $"Не удалось обновить Computer (ComputerId = {computer.Id}, CompName = {computer.Name})");
        return IsUpdated;
    }

    public int UpdateComputer(Computer computer)
    {
        return UpdateComputer(computer, this.connection);
    }

    public void Dispose()
    {
        connection.CloseAsync();
    }
}