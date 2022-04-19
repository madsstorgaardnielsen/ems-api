namespace ems_api.DTOs;

using System.Runtime.Serialization;

[DataContract]
public class UserDto {
    [DataMember] public int UserId { get; set; }
    [DataMember] public string Cpr { get; set; } = string.Empty;
    [DataMember] public string Firstname { get; set; } = string.Empty;
    [DataMember] public string Lastname { get; set; } = string.Empty;
    [DataMember] public string Address { get; set; } = string.Empty;
    [DataMember] public string Email { get; set; } = string.Empty;
    [DataMember] public string Phone { get; set; } = string.Empty;
    [DataMember] public string Password { get; set; }
    [DataMember] public string Role { get; set; }
    [DataMember] public DateTime Created { get; set; }
    [DataMember] public bool Deleted { get; set; }

    public override string ToString() {
        return "id->" + UserId + " " + "cpr->" + Cpr + " " + "firstname->" + Firstname + " " + "lastname->" + Lastname +
               " " + "adr->" + Address + " " + "email->" + Email + " " + "phone->" + Phone + " " + "pw->" + Password +
               " " + "role->" + Role + " " + "created->" + Created + " " + "deleted->" + Deleted;
    }
}