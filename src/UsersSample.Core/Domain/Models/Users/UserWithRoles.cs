namespace UsersSample.Core.Domain.Models.Users;

using System;
using System.Collections.Generic;
using UsersSample.Core.Domain.Models.Roles;

public class UserWithRoles : UserSimple
{
    public IEnumerable<RoleSimple> Roles { get; }

    public UserWithRoles(
        Guid id, 
        string firstName, 
        string lastName, 
        string username, 
        IEnumerable<RoleSimple> roles) : base(
        id, 
        firstName, 
        lastName, 
        username)
    {
        Roles = roles;
    }
}