using System.ComponentModel.DataAnnotations;

namespace HomeWork.Classes;

public class Computer
{
    [Key]
    public int Id { get; set; }
    public string PCName { get; set; }
    public string ip { get; set; }

    public string Props { get; set; }

    //public List<Accessori> Accessories { get; set; }

    public string Notation { get; set; }

    //public override string ToString()
    //{
    //    return PCName;
    //}
}