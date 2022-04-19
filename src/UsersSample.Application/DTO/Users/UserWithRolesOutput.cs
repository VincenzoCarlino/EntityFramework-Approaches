namespace UsersSample.Application.DTO.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using UsersSample.Core.Domain.Models.Users;

public class UserWithRolesOutput : UserSimpleOutput
{
    public IEnumerable<string> Roles { get; }

    protected UserWithRolesOutput(Guid id, string displayName, IEnumerable<string> roles) : base(id, displayName)
    {
        Roles = roles;
    }

    internal static UserWithRolesOutput Create(UserWithRoles user)
        => new(
            user.Id,
            GenerateUserDisplayName(user),
            user.Roles.Select(x => x.DisplayName)
        );
}