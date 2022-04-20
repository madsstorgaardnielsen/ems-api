using ems_api.Database.Enums;

namespace ems_api.DTOs;

using System.Runtime.Serialization;

public class UserDto {
    // [Required] 
    public int UserId { get; set; }

    // [Required]
    [StringLength(10, MinimumLength = 10)]
    public string Cpr { get; set; } = string.Empty;

    // [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Firstname { get; set; } = string.Empty;

    // [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Lastname { get; set; } = string.Empty;

    // [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Address { get; set; } = string.Empty;

    // [Required]
    [EmailAddress]
    [StringLength(200, MinimumLength = 2)]
    public string Email { get; set; } = string.Empty;

    // [Required]
    [Phone]
    [StringLength(11, MinimumLength = 8)]
    public string Phone { get; set; } = string.Empty;

    // [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Password { get; set; } = string.Empty;

    [EnumDataType(typeof(Role))] public string Role { get; set; }

    // [Required] 
    public DateTime Created { get; set; }
    
    // [Required] 
    public bool Deleted { get; set; }

    public override string ToString() {
        return "id->" + UserId + " " + "cpr->" + Cpr + " " + "firstname->" + Firstname + " " + "lastname->" + Lastname +
               " " + "adr->" + Address + " " + "email->" + Email + " " + "phone->" + Phone + " " + "pw->" + Password +
               " " + "role->" + Role + " " + "created->" + Created + " " + "deleted->" + Deleted;
    }
}