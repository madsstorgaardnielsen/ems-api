namespace ems_api.Models.DTOs;

public class LoginUserDTO {
    [Required]
    [DataType(DataType.EmailAddress)]
    [StringLength(200, MinimumLength = 2)]
    public string Email { get; set; }

    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string Password { get; set; }
}

public class UserDTO : LoginUserDTO {
    [Required]
    [StringLength(10, MinimumLength = 10)]
    public string Cpr { get; set; }

    [StringLength(200, MinimumLength = 2)] public string Firstname { get; set; }

    [StringLength(200, MinimumLength = 2)] public string Lastname { get; set; }

    [StringLength(200, MinimumLength = 2)] public string Address { get; set; }
    
    [Required]
    [DataType(DataType.PhoneNumber)]
    [StringLength(11, MinimumLength = 8)]
    public string Phone { get; set; }

    [Required] public DateTime Created { get; set; }
    [Required] public bool Deleted { get; set; }

    // public override string ToString() {
    //     return "id->" + UserId + " " + "cpr->" + Cpr + " " + "firstname->" + Firstname + " " + "lastname->" + Lastname +
    //            " " + "adr->" + Address + " " + "email->" + Email + " " + "phone->" + Phone + " " + "pw->" + Password +
    //            " " + "role->" + Role + " " + "created->" + Created + " " + "deleted->" + Deleted;
    // }
}