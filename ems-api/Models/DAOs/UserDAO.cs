namespace ems_api.Models.DAOs;

public class UserDAO {
    public string Firstname { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public ICollection<string> Roles { get; set; }
    public IList<Workday> Workdays { get; set; }
}