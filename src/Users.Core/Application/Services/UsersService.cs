namespace Users.Core.Application.Services;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Core.Application.DTO.Users;
using Users.Core.Domain.Repositories;

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
}