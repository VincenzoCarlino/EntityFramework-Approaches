namespace Users.Core.Domain.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Core.Domain.Models;

internal interface IUsersRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<IEnumerable<User>> GetUsersWithRoles();
    Task<IEnumerable<User>> GetUserWithRolesAndAclActions();
}