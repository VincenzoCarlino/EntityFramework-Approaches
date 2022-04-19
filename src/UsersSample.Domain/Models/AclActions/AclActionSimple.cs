namespace UsersSample.Domain.Models.AclActions;

public class AclActionSimple
{
    public string Id { get; }
    public string DisplayName { get; }
    public string Description { get; }

    public AclActionSimple(string id, string displayName, string description)
    {
        Id = id;
        DisplayName = displayName;
        Description = description;
    }
}