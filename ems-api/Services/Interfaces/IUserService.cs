namespace ems_api.Services.Interfaces;

public interface IUserService {
    Task<List<WorkdayDto>> GetAllWorkdays();
    Task<List<WorkdayDto>> GetWorkdaysFromPeriod(DateTime dateFrom, DateTime dateTo);
    Task<List<WorkdayDto>> GetWorkdaysFromPeriod(string id, DateTime dateFrom, DateTime dateTo);
    Task<string> AddWorkday(Workday workday);
    Task<string> UpdateWorkday(Workday workday);
}