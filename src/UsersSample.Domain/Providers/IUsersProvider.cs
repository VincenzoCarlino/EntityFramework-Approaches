namespace UsersSample.Domain.Providers;

using UsersSample.Domain.Models.Users;

public interface IUsersProvider
{
    IUsersProvider GetUsers();
    IUsersProvider WithRoles();
    Task<IEnumerable<IUser>> LoadAsync();
}