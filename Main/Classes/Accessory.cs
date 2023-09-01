using System.ComponentModel.DataAnnotations;

namespace HomeWork.Classes;

public class Accessory
{
    [Key]
    public long Id { get; set; }
    private string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }
}