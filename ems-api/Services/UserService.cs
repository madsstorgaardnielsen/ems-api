namespace ems_api.Services;

using Interfaces;

//TODO interface
public class UserService : IUserService {
    public Task<List<WorkdayDto>> GetAllWorkdays() {
        throw new NotImplementedException();
    }

    public Task<List<WorkdayDto>> GetWorkdaysFromPeriod(DateTime dateFrom, DateTime dateTo) {
        throw new NotImplementedException();
    }

    public Task<List<WorkdayDto>> GetWorkdaysFromPeriod(int userId, DateTime dateFrom, DateTime dateTo) {
        throw new NotImplementedException();
    }


    public Task<int> AddWorkday(WorkdayEntity workdayEntity) {
        throw new NotImplementedException();
    }

    public Task<int> UpdateWorkday(WorkdayEntity workdayEntity) {
        throw new NotImplementedException();
    }
}