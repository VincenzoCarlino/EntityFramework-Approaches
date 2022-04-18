namespace Users.Core.Domain.Models;

using System;

public class UserRole
{
    public Guid UserId { get; }
    public string RoleId { get; }

    #region EF NavigationProperties

    public Role? Role { get; private set; }
    public User? User { get; private set; }

    #endregion

    public UserRole(Guid userId, string roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}