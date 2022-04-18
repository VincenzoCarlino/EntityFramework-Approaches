namespace Users.Core.Infrastracture.Persistence.EF.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.Core.Domain.Models;
using Users.Core.Domain.Repositories;

class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UsersRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        var users = await _applicationDbContext.Users
            .ToListAsync();

        return users;
    }

    public async Task<IEnumerable<User>> GetUsersWithRoles()
    {
        var users = await _applicationDbContext.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role)
            .ToListAsync();

        return users;
    }

    public async Task<IEnumerable<User>> GetUserWithRolesAndAclActions()
    {
        
        var users = await _applicationDbContext.Users
            .Include(x => x.UserRoles)
            .ThenInclude(x => x.Role!)
            .ThenInclude(x => x.RoleAclActions!)
            .ThenInclude(x => x.AclAction)
            .ToListAsync();

        return users;
    }
}