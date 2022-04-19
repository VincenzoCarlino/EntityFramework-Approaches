namespace UsersSample.Application.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using UsersSample.Application.DTO.Users;

public interface IUsersService
{
    Task<IEnumerable<UserSimpleOutput>> GetUsersSimpleOutputAsync();
    Task<IEnumerable<UserWithRolesOutput>> GetUsersWithRolesOutputAsync();
    Task<IEnumerable<UserWithAclActionsOutput>> GetUserWithAclActionsOutput();
}