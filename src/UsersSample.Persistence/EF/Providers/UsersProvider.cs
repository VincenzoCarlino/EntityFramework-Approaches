namespace UsersSample.Persistence.EF.Providers;

using Microsoft.EntityFrameworkCore;
using UsersSample.Domain.Models.Users;
using UsersSample.Domain.Providers;
using UsersSample.Persistence.EF.Models;
using UsersSample.Persistence.Entities;

class UsersProvider : IUsersProvider
{
    private readonly ApplicationDbContext _dbContext;
    private IQueryable<DbUser> _queryable;

    public UsersProvider(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IUsersProvider GetUsers()
    {
        _queryable = _dbContext.Users;
        return this;
    }

    public IUsersProvider WithRoles()
    {
        _queryable = _queryable!.Include(x => x.UserRoles!)
            .ThenInclude(x => x.Role);

        return this;
    }

    public async Task<IEnumerable<IUser>> LoadAsync()
    {
        var users = await _queryable.ToListAsync();

        return users.Select(
            dbUser => User.Create(dbUser, _dbContext)
        ).ToList();
    }
}