namespace UsersSample.Domain.Models.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using UsersSample.Domain.Models.AclActions;
using UsersSample.Domain.Models.Roles;

public class UserWithRolesAndAclActions : UserSimple
{
    public IEnumerable<RoleWithAclActions> Roles { get; }

    public UserWithRolesAndAclActions(
        Guid id,
        string firstName,
        string lastName,
        string username,
        IEnumerable<RoleWithAclActions> roles) : base(
        id,
        firstName,
        lastName,
        username)
    {
        Roles = roles;
    }

    public IEnumerable<AclActionSimple> GetAllAclActions()
        => Roles.SelectMany(x => x.AclActions);
}