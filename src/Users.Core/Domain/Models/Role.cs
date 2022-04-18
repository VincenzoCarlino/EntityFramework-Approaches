namespace Users.Core.Domain.Models;

using System.Collections.Generic;

public class Role
{
    public string Id { get; }
    public string DisplayName { get; }
    public string Description { get; }
    
    #region EF Navigation properties

    public virtual ICollection<RoleAclAction>? RoleAclActions { get; private set; }
    public virtual ICollection<UserRole>? RoleUsers { get; private set; }

    #endregion

    public Role(string id, string displayName, string description)
    {
        Id = id;
        DisplayName = displayName;
        Description = description;
    }
}