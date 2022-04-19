using System.Runtime.Serialization;

namespace ems_api.DTOs;

[DataContract]
public class UserDtoProjection {
    [DataMember] public string Firstname { get; set; } = string.Empty;
    [DataMember] public string Lastname { get; set; } = string.Empty;
    [DataMember] public string Address { get; set; } = string.Empty;
    [DataMember] public string Email { get; set; } = string.Empty;
    [DataMember] public string Phone { get; set; } = string.Empty;
    [DataMember] public string Role { get; set; }
}