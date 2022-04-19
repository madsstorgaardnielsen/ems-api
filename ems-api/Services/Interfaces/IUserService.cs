namespace ems_api.Services.Interfaces;

public interface IUserService {
    Task<List<WorkdayDto>> GetAllWorkdays();
    Task<List<WorkdayDto>> GetWorkdaysFromPeriod(DateTime dateFrom, DateTime dateTo);
    Task<List<WorkdayDto>> GetWorkdaysFromPeriod(int userId, DateTime dateFrom, DateTime dateTo);
    Task<int> AddWorkday(WorkdayEntity workdayEntity);
    Task<int> UpdateWorkday(WorkdayEntity workdayEntity);
}