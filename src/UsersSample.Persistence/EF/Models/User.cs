namespace UsersSample.Persistence.EF.Models;

using Microsoft.EntityFrameworkCore;
using UsersSample.Domain.Models.Roles;
using UsersSample.Domain.Models.Users;
using UsersSample.Persistence.Entities;

class User : IUser
{
    private ApplicationDbContext _applicationDbContext { get; set; }

    private IEnumerable<RoleSimple>? _roles { get; set; }

    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Username { get; }

    private User(Guid id, string firstName, string lastName, string username)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Username = username;
    }

    internal static User Create(DbUser dbUser, ApplicationDbContext dbContext)
    {
        var user = new User(dbUser.Id, dbUser.FirstName, dbUser.LastName, dbUser.Username)
        {
            _applicationDbContext = dbContext
        };

        var roles = new List<DbRole>();
        var areRolesPresent = false;

        if (dbUser.UserRoles is not null)
        {
            areRolesPresent = true;
            foreach (var userRole in dbUser.UserRoles)
            {
                if (userRole.Role is null)
                {
                    areRolesPresent = false;
                    break;
                }

                roles.Add(userRole.Role);
            }
        }

        if (areRolesPresent)
        {
            user._roles = roles.Select(
                role => new RoleSimple(role.Id, role.DisplayName, role.Description)
            ).ToList();
        }

        return user;
    }

    internal void SetRoles(IEnumerable<RoleSimple> roles)
    {
        _roles = roles;
    }

    public Task<IEnumerable<RoleSimple>> GetRoles()
    {
        if (_roles is null)
        {
            return _applicationDbContext.Roles
                .Include(x => x.RoleUsers!)
                .Where(x => x.RoleUsers!.Any(x => x.UserId == Id))
                .ToListAsync()
                .ContinueWith<IEnumerable<RoleSimple>>(
                    rolesTaskResult => rolesTaskResult.Result.Select(
                            role => new RoleSimple(
                                role.Id,
                                role.DisplayName,
                                role.Description
                            )
                        )
                        .ToList()
                );
        }

        return Task.FromResult<IEnumerable<RoleSimple>>(_roles);
    }
}