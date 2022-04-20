namespace ems_api.Database.Repositories; 

public class WorkdayRepository : IWorkdayRepository{
    private readonly DatabaseContext _database;

    public WorkdayRepository(DatabaseContext context) {
        _database = context;
    }
    
    public void Dispose() {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Workday>> GetAllWorkdays() {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Workday>> GetWorkdaysFromPeriod(DateTime @from, DateTime to) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Workday>> GetWorkdaysFromPeriod(int userId, DateTime @from, DateTime to) {
        throw new NotImplementedException();
    }

    public async Task<int> AddWorkday(Workday workday) {
        if (workday == null) return -1;
        _database.Workdays.Add(workday);
        await _database.SaveChangesAsync();
        return workday.WorkdayId;
    }

    public Task<int> UpdateWorkday(Workday workday) {
        throw new NotImplementedException();
    }
}