using PetProject.Core.Domain;
using PetProject.Core.Entities;

namespace PetProject.Core.Helpers;

public static class UserExtensions
{
    public static TableFillerForUserClass ToDto(this User user)
    {
        return new TableFillerForUserClass
        {
            Id = user.Id,
            Name = user.Name,
            Password = user.Password,
            Computer = user.Computer?.Name
        };
    }
}