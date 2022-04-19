namespace ems_api.DTOs;

using System.Runtime.Serialization;

[DataContract]
public class LoginRequest {
    [DataMember] public string Email { get; set; } = string.Empty;
    [DataMember] public string Password { get; set; } = string.Empty;
}