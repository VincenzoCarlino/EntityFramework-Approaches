namespace UsersSample.Application.DTO.Users;

using System;
using System.Collections.Generic;
using UsersSample.Domain.Models.Users;

public class UserWithAclActionsOutput : UserSimpleOutput
{
    public IEnumerable<string> AclActions { get; }

    protected UserWithAclActionsOutput(Guid id, string displayName, IEnumerable<string> aclActions) : base(id, displayName)
    {
        AclActions = aclActions;
    }

    internal static UserWithAclActionsOutput Create(UserWithRolesAndAclActions user)
        => throw new NotImplementedException();
    // => new(
    //     user.Id,
    //     GenerateUserDisplayName(user),
    //     user.GetAllAclActions().Select(x => x.DisplayName)
    // );
}