using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace HomeWork;

public class Accessori
{
    [Key]
    public long Id { get; set; }
    private string Name { get; set; }

    public override string ToString()
    {
        return Name;
    }

}