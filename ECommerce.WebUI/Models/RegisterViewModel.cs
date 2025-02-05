using System.ComponentModel.DataAnnotations;

namespace ECommerce.WebUI.Models;

public class RegisterViewModel
{
    public required string Username { get; set; }

    [DataType(DataType.Password)]
    public required string Password { get; set; }

    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
}
