using ems_api.Database.Enums;

namespace ems_api.Database.Models;

[Table("Users")]
public class UserEntity {
    [Key] public int UserId { get; init; }

    [Required(ErrorMessage = "Cpr is required")]
    [MaxLength(10), MinLength(10)]
    public string Cpr { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [MaxLength(255), MinLength(2)]
    public string Firstname { get; set; }

    [MaxLength(255), MinLength(2)]
    [Required(ErrorMessage = "Last name is required")]
    public string Lastname { get; set; }

    [MaxLength(255), MinLength(2)]
    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [MaxLength(255), MinLength(2)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Phone is required")]
    [MinLength(8)]
    [Phone]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MaxLength(255), MinLength(8)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Role is required")]
    [EnumDataType(typeof(Role))]
    public string Role { get; set; }
    
    [Required]
    public DateTime Created { get; set; }

    [Required] public bool Deleted { get; set; } = false;

    public ICollection<WorkdayEntity> Workdays { get; set; }
}