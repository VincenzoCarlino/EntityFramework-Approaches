namespace UsersSample.Application.DTO.Users;

using System;
using UsersSample.Domain.Models.Users;

public class UserSimpleOutput
{
    public Guid Id { get; }
    public string DisplayName { get; }

    protected UserSimpleOutput(Guid id, string displayName)
    {
        Id = id;
        DisplayName = displayName;
    }
    internal static UserSimpleOutput Create(IUser user)
        => new(user.Id, GenerateUserDisplayName(user));

    internal static string GenerateUserDisplayName(IUser user)
        => $"{user.FirstName} {user.LastName}";
}