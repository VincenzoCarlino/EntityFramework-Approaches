namespace UsersSample.Domain.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using UsersSample.Domain.Models.Users;

public interface IUsersRepository
{
    Task<IEnumerable<UserSimple>> GetUsersAsync();
    Task<IEnumerable<UserWithRoles>> GetUsersWithRoles();
    Task<IEnumerable<UserWithRolesAndAclActions>> GetUserWithRolesAndAclActions();
}