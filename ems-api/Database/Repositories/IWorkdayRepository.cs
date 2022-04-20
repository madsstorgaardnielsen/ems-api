namespace ems_api.Database.Repositories; 

public interface IWorkdayRepository : IDisposable{
    Task<IEnumerable<Workday>> GetAllWorkdays();
    Task<IEnumerable<Workday>> GetWorkdaysFromPeriod(DateTime from, DateTime to);
    Task<IEnumerable<Workday>> GetWorkdaysFromPeriod(int userId, DateTime from, DateTime to);
    Task<int> AddWorkday(Workday workday);
    Task<int> UpdateWorkday(Workday workday);
}