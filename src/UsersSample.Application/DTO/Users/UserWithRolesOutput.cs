namespace UsersSample.Application.DTO.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersSample.Domain.Models.Users;

public class UserWithRolesOutput : UserSimpleOutput
{
    public IEnumerable<string> Roles { get; }

    protected UserWithRolesOutput(Guid id, string displayName, IEnumerable<string> roles) : base(id, displayName)
    {
        Roles = roles;
    }

    internal static async Task<UserWithRolesOutput> Create(IUser user)
        => new(
            user.Id,
            GenerateUserDisplayName(user),
            await user.GetRoles().ContinueWith(roles => roles.Result.Select(x => x.DisplayName)).ConfigureAwait(false)
        );
}