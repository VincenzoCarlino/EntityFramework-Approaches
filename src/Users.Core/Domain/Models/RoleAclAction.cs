namespace Users.Core.Domain.Models;

public class RoleAclAction
{
    public string RoleId { get; }
    public string AclActionId { get; }

    #region EF Navigation properties

    public AclAction? AclAction { get; private set; }
    public Role? Role { get; private set; }

    #endregion

    public RoleAclAction(string roleId, string aclActionId)
    {
        RoleId = roleId;
        AclActionId = aclActionId;
    }
}