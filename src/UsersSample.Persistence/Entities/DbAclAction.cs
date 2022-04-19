namespace UsersSample.Persistence.Entities;

using System.Collections.Generic;

class DbAclAction
{
    public string Id { get; }
    public string DisplayName { get; }
    public string Description { get; }

    #region EF Navigation Properties

    public ICollection<DbRoleAclAction>? AclActionRoles { get; private set; }

    #endregion

    public DbAclAction(string id, string displayName, string description)
    {
        Id = id;
        DisplayName = displayName;
        Description = description;
    }
}