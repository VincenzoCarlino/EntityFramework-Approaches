namespace Users.Application.DTO.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using global::Users.Core.Domain.Models;
using global::Users.Core.Domain.Models.Users;

public class UserWithAclActionsOutput : UserSimpleOutput
{
    public IEnumerable<string> AclActions { get; }

    protected UserWithAclActionsOutput(Guid id, string displayName, IEnumerable<string> aclActions) : base(id, displayName)
    {
        AclActions = aclActions;
    }

    internal static UserWithAclActionsOutput Create(UserWithRolesAndAclActions user)
        => new(
            user.Id,
            GenerateUserDisplayName(user),
            user.GetAllAclActions().Select(x => x.DisplayName)
        );
}