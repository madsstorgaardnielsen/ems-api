using ems_api.Database;
using ems_api.Database.Repositories;

namespace ems_api.Services;

using Interfaces;

//TODO
public class UserService : IUserService {
    private readonly IWorkdayRepository _workdayRepository;

    public UserService() {
        _workdayRepository = new WorkdayRepository(new ApplicationDbContext());
    }

    public Task<List<WorkdayDto>> GetAllWorkdays() {
        throw new NotImplementedException();
    }

    public Task<List<WorkdayDto>> GetWorkdaysFromPeriod(DateTime dateFrom, DateTime dateTo) {
        throw new NotImplementedException();
    }

    public Task<List<WorkdayDto>> GetWorkdaysFromPeriod(int userId, DateTime dateFrom, DateTime dateTo) {
        throw new NotImplementedException();
    }


    public async Task<int> AddWorkday(WorkdayEntity workdayEntity) {
        // var result = await _workdayRepository.AddWorkday(workdayEntity);
        // if (result==-1) {
        //     
        // }
        throw new NotImplementedException();
    }

    public Task<int> UpdateWorkday(WorkdayEntity workdayEntity) {
        throw new NotImplementedException();
    }
}