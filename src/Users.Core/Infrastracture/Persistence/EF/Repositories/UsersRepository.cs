namespace Users.Core.Infrastracture.Persistence.EF.Repositories;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.Core.Application.DTO.Users;
using Users.Core.Domain.Models;
using Users.Core.Domain.Models.Roles;
using Users.Core.Domain.Models.Users;
using Users.Core.Domain.Repositories;

class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public UsersRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<IEnumerable<UserSimple>> GetUsersAsync()
        => _applicationDbContext.Users
            .ToListAsync()
            .ContinueWith<IEnumerable<UserSimple>>(
                usersTaskResult => usersTaskResult.Result.Select(
                    user => new UserSimple(
                        user.Id,
                        user.FirstName,
                        user.LastName,
                        user.Username
                    )
                ).ToList()
            );

    public Task<IEnumerable<UserWithRoles>> GetUsersWithRoles()
        => _applicationDbContext.Users
            .Include(x => x.UserRoles!)
            .ThenInclude(x => x.Role)
            .ToListAsync()
            .ContinueWith<IEnumerable<UserWithRoles>>(
                usersTaskResult => usersTaskResult.Result.Select(
                    user => new UserWithRoles(
                        user.Id,
                        user.FirstName,
                        user.LastName,
                        user.Username,
                        user.UserRoles!.Select(
                            userRole => new RoleSimple(
                                userRole.Role!.Id,
                                userRole.Role!.DisplayName,
                                userRole.Role!.Description
                            )
                        )
                    )
                )
            );

    public Task<IEnumerable<UserWithRolesAndAclActions>> GetUserWithRolesAndAclActions()
        => _applicationDbContext.Users
            .Include(x => x.UserRoles!)
            .ThenInclude(x => x.Role!)
            .ThenInclude(x => x.RoleAclActions!)
            .ThenInclude(x => x.AclAction)
            .ToListAsync()
            .ContinueWith<IEnumerable<UserWithRolesAndAclActions>>(
                usersTaskResult => usersTaskResult.Result.Select(
                        user => new UserWithRolesAndAclActions(
                            user.Id,
                            user.FirstName,
                            user.LastName,
                            user.Username,
                            user.UserRoles!.Select(
                                    userRole => new RoleWithAclActions(
                                        userRole.Role!.Id,
                                        userRole.Role!.DisplayName,
                                        userRole.Role!.Description,
                                        userRole.Role!.RoleAclActions!.Select(
                                            roleAclAction => new AclActionSimple(
                                                roleAclAction.AclAction!.Id,
                                                roleAclAction.AclAction!.DisplayName,
                                                roleAclAction.AclAction!.Description
                                            )
                                        ).ToList()
                                    )
                                )
                                .ToList()
                        )
                    )
                    .ToList()
            );
}