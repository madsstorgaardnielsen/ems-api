
namespace ems_api.Models; 

[Index(nameof(EmployeeEmail), IsUnique = true)]
public class Employee {
    
    public int Id { get; set; }
    
    // [Required(ErrorMessage = "Firstname field is required.")]
    // [StringLength(maximumLength: 25, MinimumLength = 2)]
    // public string EmployeeFirstname { get; set; }
    //
    // [Required(ErrorMessage = "Lastname field is required.")]
    // [StringLength(maximumLength: 25, MinimumLength = 2)]
    // public string EmployeeLastname { get; set; }
    
    [Required(ErrorMessage = "Email field is required.")]
    [StringLength(maximumLength: 100, MinimumLength = 2)]
    [EmailAddress]
    public string EmployeeEmail { get; set; }
    
    // [Required(ErrorMessage = "Phone field is required.")]
    // [StringLength(maximumLength: 15, MinimumLength = 10)]
    // public string EmployeePhone { get; set; }
    //
    // [StringLength(maximumLength: 250)]
    // public string EmployeeAddress { get; set; }
    
    [Required(ErrorMessage = "Password field is required.")]
    [StringLength(maximumLength: 200, MinimumLength = 10)]
    public string EmployeePassword { get; set; }
    
    // [Required(ErrorMessage = "Role field is required.")]
    // public EnumRoles Role { get; set; }
}