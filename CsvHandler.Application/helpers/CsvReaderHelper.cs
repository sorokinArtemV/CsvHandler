using System.Globalization;
using CsvHandler.Core.Users.DTO;
using CsvHelper;
using Microsoft.AspNetCore.Http;

namespace CsvHandler.Application.helpers;

public class CsvReaderHelper : ICsvReaderHelper
{
    public List<UserDto> ReadCsvFile(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<UserDto>().ToList();
    }
}