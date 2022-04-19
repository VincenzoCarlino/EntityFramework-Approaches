namespace UsersSample.Core.Infrastracture.Persistence.Entities;

class DbRoleAclAction
{
    public string RoleId { get; }
    public string AclActionId { get; }

    #region EF Navigation properties

    public DbAclAction? AclAction { get; private set; }
    public DbRole? Role { get; private set; }

    #endregion

    public DbRoleAclAction(string roleId, string aclActionId)
    {
        RoleId = roleId;
        AclActionId = aclActionId;
    }
}