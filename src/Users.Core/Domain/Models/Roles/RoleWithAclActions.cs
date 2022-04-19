namespace Users.Core.Domain.Models.Roles;

using System.Collections.Generic;

public class RoleWithAclActions : RoleSimple
{
    public IEnumerable<AclActionSimple> AclActions { get; }

    public RoleWithAclActions(string id, string displayName, string description, IEnumerable<AclActionSimple> aclActions) : base(id, displayName, description)
    {
        AclActions = aclActions;
    }
}