namespace Users.Core.Application.Services;

using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Core.Application.DTO.Users;

public interface IUsersService
{
    Task<IEnumerable<UserSimpleOutput>> GetUsersSimpleOutputAsync();
}