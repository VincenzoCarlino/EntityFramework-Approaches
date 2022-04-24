namespace UsersSample.Persistence.EF.Providers;

using Microsoft.EntityFrameworkCore;
using UsersSample.Domain.Models.Users;
using UsersSample.Domain.Providers;
using UsersSample.Persistence.EF.Models;
using UsersSample.Persistence.Entities;

class UserProvider : IUserProvider
{
    private readonly ApplicationDbContext _applicationDbContext;
    private IQueryable<DbUser> _queryable;

    public UserProvider(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
        _queryable = _applicationDbContext.Users.AsQueryable();
    }


    public IUserProvider GetBy(Guid id)
    {
        _queryable = _queryable.Where(x => x.Id == id);
        return this;
    }

    public IUserProvider WithRoles()
    {
        _queryable = _queryable
            .Include(
                x => x.UserRoles!
            )
            .ThenInclude(x => x.Role);

        return this;
    }

    public async Task<IUser> LoadAsync()
    {
        var dbUser = await _queryable.FirstOrDefaultAsync()
            .ConfigureAwait(false);

        if (dbUser is null)
        {
            throw new Exception("Missing user");
        }

        return User.Create(dbUser, _applicationDbContext);
    }
}