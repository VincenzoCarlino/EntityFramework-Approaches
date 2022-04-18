namespace Users.Core.Domain.Models;

public class AclAction
{
    public string Id { get; }
    public string DisplayName { get; }
    public string Description { get; }

    public AclAction(string id, string displayName, string description)
    {
        Id = id;
        DisplayName = displayName;
        Description = description;
    }
}