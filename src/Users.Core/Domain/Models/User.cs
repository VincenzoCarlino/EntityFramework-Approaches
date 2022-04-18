namespace Users.Core.Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;

internal class User
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Username { get; }

    #region MyRegion

    internal ICollection<UserRole>? UserRoles { get; private set; }

    #endregion

    public User(Guid id, string firstName, string lastName, string username)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
    }

    public IEnumerable<Role> GetRoles()
        => UserRoles?.Select(x => x.Role)
               .Where(x => x != null) as IEnumerable<Role>
           ?? throw new Exception($"Roles not included in user {Id}");

    public IEnumerable<AclAction> GetAclActions()
        => GetRoles()
            .SelectMany(x => x.RoleAclActions?.Select(x => x.AclAction) ?? throw new Exception("Missing acl actions"));
}