namespace UsersSample.Domain.Models.Roles;

public class RoleSimple
{
    public string Id { get; }
    public string DisplayName { get; }
    public string Description { get; }

    public RoleSimple(string id, string displayName, string description)
    {
        Id = id;
        DisplayName = displayName;
        Description = description;
    }
}