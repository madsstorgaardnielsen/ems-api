// namespace ems_api.Services;
//
// public class AdminService {
//     private readonly EmployeeContext _db;
//
//     public AdminService() {
//         _db = new EmployeeContext();
//         _db.Database.EnsureCreated();
//     }
//
//     public Employee Create(Employee employee) {
//         var result = _db.Employees.Add(employee).Entity;
//         _db.SaveChanges();
//         return result;
//     }
//
//     public Employee Get(int employeeId) {
//         return _db.Employees.Find(employeeId);
//     }
//
//     public Employee Update(Employee employee) {
//         var e = _db.Employees.Find(employee.Id);
//
//         if (e == null) {
//             return null;
//         }
//         
//         _db.Entry(e).CurrentValues.SetValues(employee);
//         _db.SaveChanges();
//         return _db.Employees.Find(employee.Id);
//     }
//
//     public Employee Delete(int id) {
//         var employee = _db.Employees.Find(id);
//         return _db.Employees.Remove(employee!).Entity;
//     }
//
//     public List<Employee> Employees() {
//         return _db.Employees.ToList();
//     }
// }