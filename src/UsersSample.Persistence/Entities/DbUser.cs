namespace UsersSample.Persistence.Entities;

using System;
using System.Collections.Generic;

class DbUser
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Username { get; }

    #region MyRegion

    internal ICollection<DbUserRole>? UserRoles { get; private set; }

    #endregion

    public DbUser(Guid id, string firstName, string lastName, string username)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
    }
    
}