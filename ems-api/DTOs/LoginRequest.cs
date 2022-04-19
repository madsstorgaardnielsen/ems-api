using System.Runtime.Serialization;

namespace ems_api.DTOs;

[DataContract]
public class LoginRequest {
    [DataMember] public string Email { get; set; } = string.Empty;
    [DataMember] public string Password { get; set; } = string.Empty;
}