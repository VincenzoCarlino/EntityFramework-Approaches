namespace Users.Core.Application.DTO.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using global::Users.Core.Domain.Models;

public class UserWithRolesOutput : UserSimpleOutput
{
    public IEnumerable<string> Roles { get; }

    protected UserWithRolesOutput(Guid id, string displayName, IEnumerable<string> roles) : base(id, displayName)
    {
        Roles = roles;
    }

    internal static UserWithRolesOutput Create(User user)
        => new(
            user.Id,
            GenerateUserDisplayName(user),
            user.GetRoles().Select(x => x.DisplayName)
        );
}