namespace ems_api.Database.Models;

public class Workday {
    public int WorkdayId { get; set; }
    public string UserId { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan TimeFrom { get; set; }
    public TimeSpan TimeTo { get; set; }
}