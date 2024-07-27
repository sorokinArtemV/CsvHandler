using AutoMapper;
using CsvHandler.Core.Domain.Constants;
using CsvHandler.Core.RepositoryContracts;
using CsvHandler.Core.ServiceContracts;
using CsvHandler.Core.Users.DTO;

namespace CsvHandler.Application.Services;

public class GetAllUsersService(IUsersRepository usersRepository, IMapper mapper) : IGetAllUsersService
{
    
    public async Task<List<UserDto>> GetAllMatchingUsers(QueryParams query)
    {
        var users = await usersRepository.GetAllMatchingUsersAsync(
            query.SearchTerm, query.PageSize, query.SortDirection);
        return mapper.Map<List<UserDto>>(users);
    }
}