﻿using System.ComponentModel.DataAnnotations;

namespace PetProject.Core.Entities;

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
    public UserRole Role { get; set; }

    public Computer? Computer { get; set; }
    public bool IsWorker { get; set; }
}

public enum UserRole
{
    None,
    Admin = 1,
    Client = 2,
}