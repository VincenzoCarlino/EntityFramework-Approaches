namespace Users.Core.Domain.Models;

using System.Collections.Generic;

internal class AclAction
{
    public string Id { get; }
    public string DisplayName { get; }
    public string Description { get; }

    #region EF Navigation Properties

    public ICollection<RoleAclAction>? AclActionRoles { get; private set; }

    #endregion

    public AclAction(string id, string displayName, string description)
    {
        Id = id;
        DisplayName = displayName;
        Description = description;
    }
}