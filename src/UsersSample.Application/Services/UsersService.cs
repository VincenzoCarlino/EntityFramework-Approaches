namespace UsersSample.Application.Services;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersSample.Application.DTO.Users;
using UsersSample.Core.Domain.Repositories;

class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public Task<IEnumerable<UserSimpleOutput>> GetUsersSimpleOutputAsync()
        => _usersRepository.GetUsersAsync()
            .ContinueWith(
                usersTaskResult => usersTaskResult.Result
                    .Select(UserSimpleOutput.Create)
            );

    public Task<IEnumerable<UserWithRolesOutput>> GetUsersWithRolesOutputAsync()
        => _usersRepository.GetUsersWithRoles()
            .ContinueWith(
                usersTaskResult => usersTaskResult.Result
                    .Select(UserWithRolesOutput.Create)
            );

    public Task<IEnumerable<UserWithAclActionsOutput>> GetUserWithAclActionsOutput()
        => _usersRepository.GetUserWithRolesAndAclActions()
            .ContinueWith(
                usersTaskResult => usersTaskResult.Result
                    .Select(UserWithAclActionsOutput.Create)
            );
}