using ems_api.Database;
using ems_api.Database.Repositories;

namespace ems_api.Services;

using Interfaces;

//TODO
public class UserService : IUserService {
    private readonly IWorkdayRepository _workdayRepository;

    public UserService() {
        _workdayRepository = new WorkdayRepository(new DatabaseContext());
    }

    public Task<List<WorkdayDto>> GetAllWorkdays() {
        throw new NotImplementedException();
    }

    public Task<List<WorkdayDto>> GetWorkdaysFromPeriod(DateTime dateFrom, DateTime dateTo) {
        throw new NotImplementedException();
    }

    public Task<List<WorkdayDto>> GetWorkdaysFromPeriod(string id, DateTime dateFrom, DateTime dateTo) {
        throw new NotImplementedException();
    }


    public async Task<string> AddWorkday(Workday workday) {
        // var result = await _workdayRepository.AddWorkday(workdayEntity);
        // if (result==-1) {
        //     
        // }
        throw new NotImplementedException();
    }

    public Task<string> UpdateWorkday(Workday workday) {
        throw new NotImplementedException();
    }
}