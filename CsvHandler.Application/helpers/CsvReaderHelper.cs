using System.Globalization;
using CsvHandler.Core.Domain.Entities;
using CsvHandler.Core.RepositoryContracts;
using CsvHandler.Core.ServiceContracts;
using CsvHelper;
using Microsoft.AspNetCore.Http;

namespace CsvHandler.Application.helpers;

public class CsvReader
{
    private async Task<List<User>> ReadCsvFileAsync(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        using var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture);
        return csv.GetRecords<User>().ToList();
    }
}