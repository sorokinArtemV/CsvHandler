using CsvHandler.Core.Users.DTO;
using Microsoft.AspNetCore.Http;

namespace CsvHandler.Application.helpers;

public interface ICsvReaderHelper
{
    /// <summary>
    /// Reads csv file and returns list of users
    /// </summary>
    /// <param name="file">File to be read</param>
    /// <returns>List of users</returns>
    List<UserDto> ReadCsvFile(IFormFile file);
}