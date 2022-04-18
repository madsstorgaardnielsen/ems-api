namespace ems_api.Database.Models;

[Table("Users")]
public class UserEntity {
    [Key] public int UserId { get; set; }

    // [Display(Name = "Employee Name")]
    // [Required(ErrorMessage = "Name is required")]
    // public string EmployeeName { get; set; }
    //
    // [Display(Name = "Address")]
    // [Required(ErrorMessage = "Address is required")]
    // public string Address { get; set; }

    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}