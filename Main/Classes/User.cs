using System.ComponentModel.DataAnnotations;

namespace HomeWork.Classes;

public class User
{
    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }

    [Key]
    public long Id { get; set; }

    public string Name { get; set; }
    public string Password { get; set; }

    public Computer? Computer { get; set; }
    public bool IsWorker { get; set; }
}