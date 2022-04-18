namespace Users.Core.Domain.Models;

using System;

public class UserRole
{
    public Guid UserId { get; }
    public string RoleId { get; }

    public UserRole(Guid userId, string roleId)
    {
        UserId = userId;
        RoleId = roleId;
    }
}