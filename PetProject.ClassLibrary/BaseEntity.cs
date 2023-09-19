using System.ComponentModel.DataAnnotations;

namespace PetProject.Core;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}