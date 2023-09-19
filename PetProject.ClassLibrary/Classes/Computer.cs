using System.ComponentModel.DataAnnotations;

namespace HomeWork.Classes;

public class Computer : IComparable
{
    public Computer(string name, string ip)
    {
        Name = name;
        Ip = ip;
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Ip { get; set; }

    public string? Props { get; set; }

    //public List<Accessory>? Accessories { get; set; }

    public string? Notation { get; set; }

    public override string ToString()
    {
        return Name;
    }

    int IComparable.CompareTo(object? obj)
    {
        Computer comp = (Computer)obj!;

        return string.Compare(this.Name, comp.Name);
    }
}