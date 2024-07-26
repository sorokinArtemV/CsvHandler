using AutoMapper;
using CsvHandler.Core.Domain.Entities;

namespace CsvHandler.Application.Users.DTO;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}