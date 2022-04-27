using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ems_api.Database.Models;


[Table("Users")]
public class User : IdentityUser {
    public string Cpr { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public IList<Workday> Workdays { get; set; }
}