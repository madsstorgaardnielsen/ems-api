namespace ems_api.Models.DAOs; 

public class WorkdayDAO {
        public DateTime Date { get; set; }
        public TimeSpan TimeFrom { get; set; }
        public TimeSpan TimeTo { get; set; }
}