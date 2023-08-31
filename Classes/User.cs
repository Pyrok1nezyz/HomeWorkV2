using System.ComponentModel.DataAnnotations;

namespace HomeWork.Classes;

public class User
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }
    public string Password { get; set; }

    public Computer? Computer { get; set; }
}