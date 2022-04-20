namespace ems_api.DTOs;


public class WorkdayDTO {
    public int UserId { get; init; }
    public int WorkdayId { get; init; }
    public DateTime Date { get; set; }
    public TimeSpan TimeFrom { get; set; }
    public TimeSpan TimeTo { get; set; }
}