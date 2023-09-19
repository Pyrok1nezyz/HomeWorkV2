using System.ComponentModel;
using HomeWork.Classes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using Computer = HomeWork.Classes.Computer;

namespace HomeWork.Db;

public sealed class MySQLDbContext : IDisposable
{
    public MySqlConnection connection;
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
        var query = "SELECT Id,Name,Password,ComputerId,IsWorker FROM Users";
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
        var query = "SELECT Id,Name,Id_parentCategory,IsMain FROM Categories";
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
        var query = "SELECT Id,Name,Ip,Notation,Props FROM Computers";
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
                            Price = reader.GetInt32(4),
                            Count = reader.GetInt32(5),
                            IsForceBuy = Convert.ToBoolean(reader.GetBoolean(6)),
                            Ids_CountryOfDeliverys = GetListCountrys(reader.GetString(7)),
                            IsDiscounted = Convert.ToBoolean(reader.GetInt32(8)),
                            IsDeleted = Convert.ToBoolean(reader.GetInt32(9)),
                            IsHided = Convert.ToBoolean(reader.GetInt32(10)),
                            Id_Byer = reader.GetInt32(11)
                        };
                    }
                    else
                    {
                        if (reader.IsDBNull(3))
                        {
                            item = new Item()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                MainCategory = categories.Find(e => e.Id == reader.GetInt32(2)),
                                Price = reader.GetInt32(4),
                                Count = reader.GetInt32(5),
                                IsForceBuy = Convert.ToBoolean(reader.GetBoolean(6)),
                                Ids_CountryOfDeliverys = GetListCountrys(reader.GetString(7)),
                                IsDiscounted = Convert.ToBoolean(reader.GetInt32(8)),
                                IsDeleted = Convert.ToBoolean(reader.GetInt32(9)),
                                IsHided = Convert.ToBoolean(reader.GetInt32(10)),
                                Id_Byer = reader.GetInt32(11)
                            };
                        }
                        else
                        {
                            item = new Item()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                MainCategory = categories.Find(e => e.Id == reader.GetInt32(2)),
                                SubCategory = categories.Find(e => e.Id == reader.GetInt32(3)),
                                Price = reader.GetInt32(4),
                                Count = reader.GetInt32(5),
                                IsForceBuy = Convert.ToBoolean(reader.GetBoolean(6)),
                                Ids_CountryOfDeliverys = GetListCountrys(reader.GetString(7)),
                                IsDiscounted = Convert.ToBoolean(reader.GetInt32(8)),
                                IsDeleted = Convert.ToBoolean(reader.GetInt32(9)),
                                IsHided = Convert.ToBoolean(reader.GetInt32(10)),
                                Id_Byer = reader.GetInt32(11)
                            };
                        }
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
        var categories = new MySQLDbContext().GetCategories();

        if (categories.Any(e => e.Id == category.id_parentCategory))
        {
            throw new Exception("Отсуствует зависимость: не обнаружена родительская категория");
        }

        var query =
            $"INSERT INTO categories (Name, CategoryId, IsMain) VALUES (@Name,@Id_parentCategory,@IsMain);";
        var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.Add(new MySqlParameter("@Name", category.Name));
        cmd.Parameters.Add(new MySqlParameter("@Id_parentCategory", category.id_parentCategory));
        cmd.Parameters.Add(new MySqlParameter("@IsMain", Convert.ToInt32(category.IsMain)));

        var IsAdded = cmd.ExecuteNonQuery();
        if (IsAdded == 0) throw new Exception("не удалось добавить категорию");
        return IsAdded;
    }

    public int AddCategory(Category category)
    {
        return AddCategory(category, this.connection);
    }

    public int AddItem(Item item, MySqlConnection connection)
    {
        if (item.MainCategory == null)
            item.MainCategory = new Category();
        else if(item.SubCategory == null)
        {
            item.SubCategory = new Category();
        }

        var query =
            $"INSERT INTO items (Name, Id_MainCategory, Id_SubCategory, Price, Count, IsForceBuy, ids_CountryOfDeliverys, IsDiscounted, IsDeleted, isHided, IdByer) " +
            $"VALUES (@Name,@Id_MainCategory,@Id_SubCategory,@Price,@Count,@IsForceBuy,@Ids_CountryOfDeliverys,@IsDiscounted,@IsDeleted,@IsHided,@Id_Byer);";
        var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.Add(new MySqlParameter("@Name", item.Name));
        cmd.Parameters.Add(new MySqlParameter("@Id_MainCategory", item.MainCategory!.Id));
        cmd.Parameters.Add(new MySqlParameter("@Id_SubCategory", item.SubCategory!.Id));
        cmd.Parameters.Add(new MySqlParameter("@Price", item.Price));
        cmd.Parameters.Add(new MySqlParameter("@Count", item.Count));
        cmd.Parameters.Add(new MySqlParameter("@IsForceBuy", Convert.ToInt32(item.IsForceBuy)));
        cmd.Parameters.Add(new MySqlParameter("@Ids_CountryOfDeliverys",
            string.Join('|', item.Ids_CountryOfDeliverys)));
        cmd.Parameters.Add(new MySqlParameter("@IsDiscounted", Convert.ToInt32(item.IsDiscounted)));
        cmd.Parameters.Add(new MySqlParameter("@IsDeleted", Convert.ToInt32(item.IsDeleted)));
        cmd.Parameters.Add(new MySqlParameter("@IsHided", Convert.ToInt32(item.IsHided)));
        cmd.Parameters.Add(new MySqlParameter("@Id_Byer", item.Id_Byer));

        var IsAdded = cmd.ExecuteNonQuery();
        if (IsAdded == 0) throw new Exception("Не удалось добавить товар в таблицу товаров");
        return IsAdded;
    }

    public int AddItem(Item item)
    {
        return AddItem(item, this.connection);
    }

    public int AddUser(User user, MySqlConnection connection)
    {
        int n = Convert.ToInt32(user.IsWorker);

        var query = $"INSERT INTO Users (Name, Password, ComputerId, IsWorker) VALUES (@Name,@Password,@ComputerId,@IsWorker);";
        MySqlCommand cmd = new MySqlCommand(query, connection);

        cmd.Parameters.Add(new MySqlParameter("@Name", user.Name));
        cmd.Parameters.Add(new MySqlParameter("@Password", user.Password));
        cmd.Parameters.Add(new MySqlParameter("@ComputerId", user.Computer.Id));
        cmd.Parameters.Add(new MySqlParameter("@IsWorker", user.IsWorker));


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
        var query = $"INSERT INTO Computers (Name, Ip, Props, Notation) VALUES (@Name,@Ip,@Props,@Notation);";
        MySqlCommand cmd = new MySqlCommand(query, connection);

        cmd.Parameters.Add(new MySqlParameter("@Name", computer.Name));
        cmd.Parameters.Add(new MySqlParameter("@Name", computer.Ip));
        cmd.Parameters.Add(new MySqlParameter("@Name", computer.Props));
        cmd.Parameters.Add(new MySqlParameter("@Name", computer.Notation));

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

        var query =
            $"UPDATE Users SET Name=@Name,Password=@Password,ComputerId=@ComputerId,IsWorker=@IsWorker WHERE Id=@Id;";
        var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.Add(new MySqlParameter("@Name", user.Name));
        cmd.Parameters.Add(new MySqlParameter("@Password", user.Password));
        cmd.Parameters.Add(new MySqlParameter("@ComputerId", user.Computer));
        cmd.Parameters.Add(new MySqlParameter("@IsWorker", user.IsWorker));

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
            $"UPDATE Computers SET Name=@Name,Ip=@Ip,Notation=@Notation,Props=@Props WHERE Id=@Id";
        var cmd = new MySqlCommand(query, connection);
        cmd.Parameters.Add(new MySqlParameter("@Name", computer.Name));
        cmd.Parameters.Add(new MySqlParameter("@Ip", computer.Ip));
        cmd.Parameters.Add(new MySqlParameter("@Notation", computer.Notation));
        cmd.Parameters.Add(new MySqlParameter("@Props", computer.Props));
        cmd.Parameters.Add(new MySqlParameter("@Id", computer.Id));

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