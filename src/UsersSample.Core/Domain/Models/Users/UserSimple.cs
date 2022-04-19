namespace UsersSample.Core.Domain.Models.Users;

using System;

public class UserSimple
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Username { get; }

    public UserSimple(Guid id, string firstName, string lastName, string username)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
    }
}