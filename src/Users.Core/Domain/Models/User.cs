namespace Users.Core.Domain.Models;

using System;
using System.Collections.Generic;

internal class User
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Username { get; }

    #region MyRegion

    public ICollection<UserRole> UserRoles { get; private set; }

    #endregion

    public User(Guid id, string firstName, string lastName, string username)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
    }
}