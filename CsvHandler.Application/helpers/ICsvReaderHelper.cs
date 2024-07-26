using CsvHandler.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace CsvHandler.Application.helpers;

public interface ICsvReaderHelper
{
    List<User> ReadCsvFileAsync(IFormFile file);
}