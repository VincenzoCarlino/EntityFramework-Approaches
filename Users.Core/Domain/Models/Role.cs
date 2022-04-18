namespace Users.Core.Domain.Models;

public class Role
{
    public string Id { get; }
    public string DisplayName { get; }
    public string Description { get; }

    public Role(string id, string displayName, string description)
    {
        Id = id;
        DisplayName = displayName;
        Description = description;
    }
}