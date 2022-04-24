namespace UsersSample.Domain.Models.Users;

using UsersSample.Domain.Models.Roles;

public interface IUser
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Username { get; }

    public Task<IEnumerable<RoleSimple>> GetRoles();
}