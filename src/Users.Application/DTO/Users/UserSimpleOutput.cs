namespace Users.Application.DTO.Users;

using System;
using global::Users.Core.Domain.Models.Users;

public class UserSimpleOutput
{
    public Guid Id { get; }
    public string DisplayName { get; }

    protected UserSimpleOutput(Guid id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }
    internal static UserSimpleOutput Create(UserSimple user)
        => new(user.Id, GenerateUserDisplayName(user));

    internal static string GenerateUserDisplayName(UserSimple user)
        => $"{user.FirstName} {user.LastName}";
}