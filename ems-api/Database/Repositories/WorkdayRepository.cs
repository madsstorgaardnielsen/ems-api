namespace ems_api.Database.Repositories; 

public class WorkdayRepository : IWorkdayRepository{
    private readonly ApplicationDbContext _database;

    public WorkdayRepository(ApplicationDbContext context) {
        _database = context;
    }
    
    public void Dispose() {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WorkdayEntity>> GetAllWorkdays() {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WorkdayEntity>> GetWorkdaysFromPeriod(DateTime @from, DateTime to) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<WorkdayEntity>> GetWorkdaysFromPeriod(int userId, DateTime @from, DateTime to) {
        throw new NotImplementedException();
    }

    public async Task<int> AddWorkday(WorkdayEntity workdayEntity) {
        if (workdayEntity == null) return -1;
        _database.Workdays.Add(workdayEntity);
        await _database.SaveChangesAsync();
        return workdayEntity.WorkdayId;
    }

    public Task<int> UpdateWorkday(WorkdayEntity workdayEntity) {
        throw new NotImplementedException();
    }
}