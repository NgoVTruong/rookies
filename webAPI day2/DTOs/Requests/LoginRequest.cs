using System.ComponentModel.DataAnnotations;

namespace webAPI_day2.DTOs.Requests;

public class LoginRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

}