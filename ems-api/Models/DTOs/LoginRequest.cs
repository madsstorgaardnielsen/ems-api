namespace ems_api.DTOs;

using System.Runtime.Serialization;

public class LoginRequest {
     public string Email { get; set; } = string.Empty;
     public string Password { get; set; } = string.Empty;
}