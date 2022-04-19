namespace Users.Core.Infrastracture.Persistence.Entities;

using System.Collections.Generic;
class DbRole
{
    public string Id { get; }
    public string DisplayName { get; }
    public string Description { get; }
    
    #region EF Navigation properties

    public virtual ICollection<DbRoleAclAction>? RoleAclActions { get; private set; }
    public virtual ICollection<DbUserRole>? RoleUsers { get; private set; }

    #endregion
    
    public DbRole(string id, string displayName, string description)
    {
        Id = id;
        DisplayName = displayName;
        Description = description;
    }
}