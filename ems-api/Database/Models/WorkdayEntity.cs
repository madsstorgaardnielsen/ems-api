namespace ems_api.Database.Models;

public class WorkdayEntity {
    [Key] public int WorkdayId { get; init; }
    
    public int UserId { get; set; }
    
    public UserEntity User { get; set; }
    
    [Required(ErrorMessage = "Date is required")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Time from is required")]
    public TimeSpan TimeFrom { get; set; }

    [Required(ErrorMessage = "Time to is required")]
    public TimeSpan TimeTo { get; set; }
}