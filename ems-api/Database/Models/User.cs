using Microsoft.AspNetCore.Identity;

namespace ems_api.Database.Models;


[Table("Users")]
public class User : IdentityUser {

    public string Cpr { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }
    
    public string Address { get; set; }
    
    public string Role { get; set; }

    public DateTime Created { get; set; }

    public bool Deleted { get; set; }

    public IList<Workday> Workdays { get; set; }
}