namespace Users.Core.Application.DTO.Users;

using System;
using System.Collections.Generic;
using System.Linq;
using global::Users.Core.Domain.Models;

public class UserWithAclActionsOutput : UserSimpleOutput
{
    public IEnumerable<string> AclActions { get; }

    protected UserWithAclActionsOutput(Guid id, string displayName, IEnumerable<string> aclActions) : base(id, displayName)
    {
        AclActions = aclActions;
    }

    internal static UserWithAclActionsOutput Create(User user)
        => new(
            user.Id,
            GenerateUserDisplayName(user),
            user.GetAclActions().Select(x => x.DisplayName)
        );
}