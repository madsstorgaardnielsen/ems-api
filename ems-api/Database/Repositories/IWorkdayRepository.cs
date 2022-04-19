namespace ems_api.Database.Repositories; 

public interface IWorkdayRepository : IDisposable{
    Task<IEnumerable<WorkdayEntity>> GetAllWorkdays();
    Task<IEnumerable<WorkdayEntity>> GetWorkdaysFromPeriod(DateTime from, DateTime to);
    Task<IEnumerable<WorkdayEntity>> GetWorkdaysFromPeriod(int userId, DateTime from, DateTime to);
    Task<int> AddWorkday(WorkdayEntity workdayEntity);
    Task<int> UpdateWorkday(WorkdayEntity workdayEntity);
}