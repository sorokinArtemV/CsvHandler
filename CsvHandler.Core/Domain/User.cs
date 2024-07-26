using System.ComponentModel.DataAnnotations;

namespace CsvHandler.Core;

public class User
{
    [Key]
    public Guid UserIdentifier { get; set; }
    public string? Username { get; set; }
    public int Age { get; set; }
    public string? City { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
}