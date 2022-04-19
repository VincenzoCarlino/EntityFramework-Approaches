namespace UsersSample.Core.Infrastracture.Persistence.Entities;

using System;

class DbUserRole
{
    public Guid UserId { get; }
    public string RoleId { get; }

    #region EF NavigationProperties

    public DbRole? Role { get; private set; }
    public DbUser? User { get; private set; }

    #endregion

    public DbUserRole(Guid userId, string roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}