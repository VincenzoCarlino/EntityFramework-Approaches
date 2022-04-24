namespace UsersSample.Application.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersSample.Application.DTO.Users;
using UsersSample.Domain.Providers;
using UsersSample.Domain.Repositories;

class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUsersProvider _usersProvider;
    private readonly IUserProvider _userProvider;

    public UsersService(IUsersRepository usersRepository, IUserProvider userProvider, IUsersProvider usersProvider)
    {
        _usersRepository = usersRepository;
        _userProvider = userProvider;
        _usersProvider = usersProvider;
    }

    public async Task<IEnumerable<UserSimpleOutput>> GetUsersSimpleOutputAsync()
    {
        // var user = await _userProvider.GetBy(Guid.Parse("81cc1b60-cbc6-4bac-9561-24ee17e1910b"))
        //     .LoadAsync();
        //
        // var roles = await user.GetRoles();

        var users = await _usersProvider.GetUsers()
            .LoadAsync();

        return users.Select(UserSimpleOutput.Create);
    }

    public async Task<IEnumerable<UserWithRolesOutput>> GetUsersWithRolesOutputAsync()
    {
        var usersOutput = new List<UserWithRolesOutput>();

        var users = await _usersProvider.GetUsers()
            // .WithRoles()
            .LoadAsync()
            .ConfigureAwait(false);
        
        foreach (var user in users)
        {
            usersOutput.Add(
                await UserWithRolesOutput.Create(user).ConfigureAwait(false)
            );
        }

        return usersOutput;
    }

    public Task<IEnumerable<UserWithAclActionsOutput>> GetUserWithAclActionsOutput()
        => _usersRepository.GetUserWithRolesAndAclActions()
            .ContinueWith(
                usersTaskResult => usersTaskResult.Result
                    .Select(UserWithAclActionsOutput.Create)
            );
}