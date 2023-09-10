using HomeWork.Classes;
using MySql.Data.MySqlClient;
using Computer = HomeWork.Classes.Computer;

namespace HomeWork.Db;

public sealed class MySQLDbContext : IDisposable
{
    internal static List<Category> _categories = null!;
    internal static List<Item> _items = null!;
    protected internal MySqlConnection connection;
    public MySQLDbContext()
    {
        string connectionString = "server=localhost;user=root;password=telega123;database=usersdb;";
        connection = GetConnection(connectionString);
        connection.Open();

        _categories = GetCategories();
        _items = GetItems();
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
                            IsWorker = reader.GetBoolean(4),
                            Computer = listComputers.Find(e => e.Id == reader.GetInt32(3))
                        };
                    }
                    else
                    {
                        user = new User(reader.GetString(1), reader.GetString(2))
                        {
                            Id = reader.GetInt64(0),
                            IsWorker = reader.GetBoolean(4)
                        };
                    }

                    list.Add(user);
                }
            }
        }

        return list;
    }

    public List<Category> GetCategories(MySqlConnection connection)
    {
        var query = "SELECT * FROM Categories";
        var cmd = new MySqlCommand(query, connection);
        var list = new List<Category>();

        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Category category;

                    if (reader.IsDBNull(2))
                    {
                        category = new Category()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            IsMain = Convert.ToBoolean(reader.GetValue(3))
                        };

                        if (category.id_parentCategory == null && category.IsMain == false)
                            throw new Exception(
                                "Ошибка парсинга категории, категория не имеет родителя и IsMain = false");
                    }
                    else
                    {
                        category = new Category()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            id_parentCategory = reader.GetInt32(2),
                            IsMain = Convert.ToBoolean(reader.GetValue(3))
                        };

                        if(category.id_parentCategory != null && category.IsMain == true) 
                            throw new Exception("Ошибка парсинга категории, категория имеет родителя и IsMain = true");
                    }

                    list.Add(category);
                }
            }
        }

        return list;
    }

    public List<Category> GetCategories()
    {
        return GetCategories(this.connection);
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

    public List<Item> GetItems(MySqlConnection connection)
    {
        var query = "SELECT * FROM items";
        var cmd = new MySqlCommand(query, connection);

        var list = new List<Item>();
        var categories = GetCategories();

        using (MySqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Item item;

                    if (reader.IsDBNull(2))
                    {
                        item = new Item()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetInt32(3),
                            Count = reader.GetInt32(4),
                            IsForceBuy = Convert.ToBoolean(reader.GetBoolean(5)),
                            Ids_CountryOfDeliverys = GetListCountrys(reader.GetString(6)),
                            IsDiscounted = Convert.ToBoolean(reader.GetInt32(7)),
                            IsDeleted = Convert.ToBoolean(reader.GetInt32(8)),
                            IsHided = Convert.ToBoolean(reader.GetInt32(9)),
                            Id_Byer = reader.GetInt32(10)
                        };
                    }
                    else
                    {
                        item = new Item()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Category = categories.Find(e => e.Id == reader.GetInt32(2)),
                            Price = reader.GetInt32(3),
                            Count = reader.GetInt32(4),
                            IsForceBuy = Convert.ToBoolean(reader.GetBoolean(5)),
                            Ids_CountryOfDeliverys = GetListCountrys(reader.GetString(6)),
                            IsDiscounted = Convert.ToBoolean(reader.GetInt32(7)),
                            IsDeleted = Convert.ToBoolean(reader.GetInt32(8)),
                            IsHided = Convert.ToBoolean(reader.GetInt32(9)),
                            Id_Byer = reader.GetInt32(10)
                        };
                    }

                    

                    list.Add(item);
                }
            }
        }

        return list;
    }

    private List<int> GetListCountrys(string getString)
    {
        var list = new List<int>();
        var listIds = getString.Trim().Split('|');
        foreach (var qq in listIds)
        {
            var n = 0;
            int.TryParse(qq, out n);
            list.Add(n);
        }

        return list;
    }

    public List<Item> GetItems()
    {
        return GetItems(this.connection);
    }

    public int AddCategory(Category category, MySqlConnection connection)
    {
        if (_categories.Any(e => e.Id == category.id_parentCategory))
        {
            throw new Exception("Отсуствует зависимость: не обнаружена родительская категория");
        }

        var query =
            $"INSERT INTO categories (Name, CategoryId, IsMain) VALUES ('{category.Name}','{category.id_parentCategory}','{Convert.ToInt32(category.IsMain)}');";
        var cmd = new MySqlCommand(query, connection);
        var IsAdded = cmd.ExecuteNonQuery();
        if (IsAdded == 0) throw new Exception("не удалось добавить категорию");
        _categories.Add(category);
        return IsAdded;
    }

    public int AddCategory(Category category)
    {
        return AddCategory(category, this.connection);
    }

    public int AddItem(Item item, MySqlConnection connection)
    {
        var query =
            $"INSERT INTO items (Name, Id_Category, Price, Count, IsForceBuy, ids_CountryOfDeliverys, IsDiscounted, IsDeleted, isHided, IdByer) " +
            $"VALUES ('{item.Name}','{item.Category!.Id}','{item.Price}','{item.Count}','{Convert.ToInt32(item.IsForceBuy)}','{string.Join('|', item.Ids_CountryOfDeliverys!)}','{Convert.ToInt32(item.IsDiscounted)}','{Convert.ToInt32(item.IsDeleted)}','{Convert.ToInt32(item.IsHided)}','{item.Id_Byer}');";

        MySqlCommand cmd = new MySqlCommand(query, connection);
        var IsAdded = cmd.ExecuteNonQuery();
        if (IsAdded == 0) throw new Exception("Не удалось добавить товар в таблицу товаров");
        _items.Add(item);
        return IsAdded;
    }

    public int AddItem(Item item)
    {
        return AddItem(item, this.connection);
    }

    public int AddUser(User user, MySqlConnection connection)
    {
        int n = Convert.ToInt32(user.IsWorker);

        var query = user.Computer != null 
            ? $"INSERT INTO Users (Name, Password, ComputerId, IsWorker) VALUES ('{user.Name}','{user.Password}','{user.Computer.Id}','{n}');" 
            : $"INSERT INTO Users (Name, Password) VALUES ('{user.Name}','{user.Password}','{n}');";
        MySqlCommand cmd = new MySqlCommand(query, connection);
        var IsAdded = cmd.ExecuteNonQuery();
        if (IsAdded == 0) throw new Exception("Не удалось добавить юзера в таблицу Users");
        return IsAdded;
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
        int n = Convert.ToInt32(user.IsWorker);

        var query = user.Computer != null
            ? $"UPDATE Users SET Name='{user.Name}',Password='{user.Password}',ComputerId='{user.Computer.Id}',IsWorker='{n}' WHERE Id='{user.Id}';"
            : $"UPDATE Users SET Name='{user.Name}',Password='{user.Password}',IsWorker='{n}' WHERE Id='{user.Id}';";
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
            $"UPDATE Computers SET Name='{computer.Name}',Ip='{computer.Ip}',Notation='{computer.Notation}',Props='{computer.Props}' WHERE Id='{computer.Id}'";
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