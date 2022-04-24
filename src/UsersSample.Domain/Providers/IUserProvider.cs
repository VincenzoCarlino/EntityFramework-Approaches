namespace UsersSample.Domain.Providers;

using UsersSample.Domain.Models.Users;

public interface IUserProvider
{
    IUserProvider GetBy(Guid id);
    IUserProvider WithRoles();
    Task<IUser> LoadAsync();
}